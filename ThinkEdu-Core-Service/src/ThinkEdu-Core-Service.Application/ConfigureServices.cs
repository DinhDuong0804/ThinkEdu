using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ThinkEdu_Core_Service.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        return services;
    }
}