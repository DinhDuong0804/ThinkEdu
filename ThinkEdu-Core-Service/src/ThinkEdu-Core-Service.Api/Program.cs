using Microsoft.AspNetCore.Localization;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Globalization;
using ThinkEdu_Core_Service.Application;
using ThinkEdu_Core_Service.Domain.Extensions;
using ThinkEdu_Core_Service.Infrastructure;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

var builder = WebApplication.CreateBuilder(args);

builder.AddAppConfigurations();
builder.Services.AddCors(options => options.AddPolicy(name: "AllowSpecificOrigins",
       policy =>
       {
           policy.WithOrigins("*")
               .AllowAnyHeader()
               .AllowAnyMethod()
               ;
       }));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddLocalization();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
var supportedCultures = new List<CultureInfo>
    {
        new CultureInfo("vi-VN"),
        new CultureInfo("en-US"),
    };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(culture: "vi-VN", uiCulture: "vi-VN"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.AddApplicationBuilders();
app.MigrateDatabase();
app.MapControllers();
app.Run();
