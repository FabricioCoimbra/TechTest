using Microsoft.OpenApi.Models;
using System.Reflection;

namespace TechTest.IoC
{
    public static class DependencyInjectionSwagger
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Nice API for testing technologies",
                    Description = "API to test my skills with Asp.net core mvc and simple tests with XUnit",
                    TermsOfService = new Uri("https://docs.github.com/en/site-policy/github-terms/github-open-source-applications-terms-and-conditions"),
                    Contact = new()
                    {
                        Name = "Fabricio Coimbra",
                        Email = "fabriciob.coimbra@gmail.com",
                        Url = new Uri("https://github.com/FabricioCoimbra/TechTest")
                    }
                });
                var filePath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
                c.IncludeXmlComments(filePath);
            });

            return services;
        }
    }
}
