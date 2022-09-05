using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<TwitterClient>(options => {
                options.BaseAddress = new Uri(configuration["TwitterApi:BaseUri"]);
                options.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", configuration["TwitterApi:Token"]);
            });
        }
    }
}
