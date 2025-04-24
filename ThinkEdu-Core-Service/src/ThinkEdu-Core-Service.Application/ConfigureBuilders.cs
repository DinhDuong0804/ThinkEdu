using Microsoft.AspNetCore.Builder;
using ThinkEdu_Core_Service.Application.Middleware;

namespace ThinkEdu_Core_Service.Application
{
    public static class ConfigureBuilders
    {
        public static IApplicationBuilder AddApplicationBuilders(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}