using ABTS.BLL.Abstract;
using ABTS.BLL.Concrete;
using ABTS.DAL.Abstract;
using ABTS.DAL.Concrete.EF;
using ABTS.ElasticService.Abstract;
using ABTS.ElasticService.Concrete;
using ABTS.RedisService.Abstract;
using ABTS.RedisService.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ABTS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NorthwindContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("MSSQL")));
            services.AddScoped<IProductDAL,ProductDAL>();
            services.AddScoped<ICategoryDAL, CategoryDAL>();
            services.AddScoped<ISupplierDAL, SupplierDAL>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<ISupplierManager, SupplierManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IElasticSearchService, ElasticSearchService>();
            services.AddScoped<IProductElasticService, ProductElasticService>();
            services.AddScoped<IRedisService, RedisService.Concrete.RedisService>();
            services.AddSingleton<IRedisConnectionFactory, RedisConnectionFactory>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();
            //app.UseMvc(mvc =>
            //{
            //    mvc.MapRoute(
            //        name: "default_route",
            //        template: "api/{controller}/{action}/{id?}",
            //        defaults: new { controller = "Home", action = "Index" });
            //});
        }
    }
}
