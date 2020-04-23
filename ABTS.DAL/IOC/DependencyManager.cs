using ABTS.DAL.Abstract;
using ABTS.DAL.Concrete.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ABTS.DAL.IOC
{
    public static class DependencyManager
    {
        public static void RegisterDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NorthwindContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("Postgres")));
            services.AddScoped<IProductDAL, ProductDAL>();
            services.AddScoped<ICategoryDAL, CategoryDAL>();
            services.AddScoped<ISupplierDAL, SupplierDAL>();
        }
    }
}
