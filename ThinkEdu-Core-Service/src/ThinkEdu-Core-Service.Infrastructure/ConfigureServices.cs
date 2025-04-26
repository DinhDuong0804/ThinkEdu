using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ThinkEdu_Core_Service.Application.Common;
using ThinkEdu_Core_Service.Domain.Configurations;
using ThinkEdu_Core_Service.Domain.Extensions;
using ThinkEdu_Core_Service.Infrastructure.Common;
using ThinkEdu_Core_Service.Infrastructure.Persistence;

namespace ThinkEdu_Core_Service.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var databaseSettings = services.GetOptions<DatabaseSettings>(nameof(DatabaseSettings));
        if (databaseSettings == null || string.IsNullOrEmpty(databaseSettings.ConnectionString))
            throw new ArgumentNullException("Connection string is not configured.");

        services.AddDbContext<CoreDbContext>(option =>
        {
            option.UseNpgsql(databaseSettings.ConnectionString, builder =>
                builder.MigrationsAssembly(typeof(CoreDbContext).Assembly.FullName));
        });

        services
            .AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>))
            .AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders()
                        ;
                });
        });

        services.RegisterAssemblyServices();

        return services;
    }

    public static IHost MigrateDatabase(this IHost host)
    {
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<CoreDbContext>();
        dbContext.Database.Migrate();
        return host;
    }

    private static IServiceCollection RegisterAssemblyServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var serviceTypes = assembly.GetExportedTypes()
            .Where(t => t.IsClass && !t.IsAbstract);

        foreach (var serviceType in serviceTypes)
        {
            var interfaces = serviceType.GetInterfaces();
            var mainInterface = interfaces.FirstOrDefault(i =>
                (i.Name.StartsWith("I") && i.Name.EndsWith("Service"))
                || (i.Name.StartsWith("I") && i.Name.EndsWith("Repository"))
            );
            if (mainInterface != null) services.AddScoped(mainInterface, serviceType);
        }

        return services;
    }
}