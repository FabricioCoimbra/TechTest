using TechTest.Service;

namespace TechTest.IoC
{
    public static class DependencyInjectionServices
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {

            services.AddScoped<ITeamScoresService, TeamScoresService>();
            services.AddScoped<IArticleService, ArticleService>();

            return services;
        }
    }
}
