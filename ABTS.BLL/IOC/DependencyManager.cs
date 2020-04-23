using ABTS.BLL.Abstract;
using ABTS.BLL.Concrete;
using ABTS.DAL.IOC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ABTS.BLL.IOC
{
    public static class DependencyManager
    {
        public static void RegisterBLL(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterDataAccess(configuration);
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<ISupplierManager, SupplierManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
        }
    }
}
