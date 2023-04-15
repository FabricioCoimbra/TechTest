using Microsoft.AspNetCore.HttpLogging;

namespace TechTest.IoC
{
    public static class DependencyInjectionLogging
    {
        public static IServiceCollection AddLog(this IServiceCollection services)
        {
            services.AddLogging();
            services.AddHttpLogging(options =>
                options.LoggingFields = HttpLoggingFields.ResponseStatusCode |
                    HttpLoggingFields.RequestPath |
                    HttpLoggingFields.ResponseBody);

            return services;
        }
    }
}
