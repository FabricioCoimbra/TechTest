using TechTest.Service;

namespace TechTest.IoC
{
    public static class DependencyInjectionHypnoboxRequester
    {
        public static IServiceCollection AddHypnoboxRequester(this IServiceCollection services, IConfiguration configuration)
        {
            var config = new EnviromentConfig();
            configuration.GetSection(EnviromentConfig.Section).Bind(config);

            //https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-7.0
            services.AddHttpClient("HypnoBox", client =>
            {
                client.BaseAddress = new Uri(config.Host);
                client.Timeout = TimeSpan.FromSeconds(10);
            });

            services.AddScoped<IHypnoBoxRequester, HypnoBoxRequester>();
            return services;
        }
    }
}
