using ABTS.RedisService.Abstract;
using ABTS.RedisService.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ABTS.RedisService.IOC
{
    public static class DependencyManager
    {
        public static void RegisterRedisService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRedisService, RedisService.Concrete.RedisService>();
            services.AddSingleton<IRedisConnectionFactory, RedisConnectionFactory>();
        }
    }
}
