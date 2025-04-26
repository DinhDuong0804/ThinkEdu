using Microsoft.AspNetCore.Localization;
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
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddLocalization();
builder.Services.AddSwaggerGen();
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

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.AddApplicationBuilders();
app.MigrateDatabase();
app.MapControllers();

app.Run();
