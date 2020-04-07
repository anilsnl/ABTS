using ABTS.ElasticService.Abstract;
using ABTS.ElasticService.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ABTS.ElasticService.IOC
{
    public static class DependencyManager
    {
        public static void RegisterElasticSearchService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IElasticSearchService, ElasticSearchService>();
            services.AddScoped<IProductElasticService, ProductElasticService>();
            services.AddSingleton<Helper>();
        }
    }
}
