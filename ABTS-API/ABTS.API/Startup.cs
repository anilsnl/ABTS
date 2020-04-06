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
using Microsoft.OpenApi.Models;

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
            services.AddScoped<IProductDAL, ProductDAL>();
            services.AddScoped<ICategoryDAL, CategoryDAL>();
            services.AddScoped<ISupplierDAL, SupplierDAL>();
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<ISupplierManager, SupplierManager>();
            services.AddScoped<ICategoryManager, CategoryManager>();
            services.AddScoped<IElasticSearchService, ElasticSearchService>();
            services.AddScoped<IProductElasticService, ProductElasticService>();
            services.AddScoped<IRedisService, RedisService.Concrete.RedisService>();
            services.AddSingleton<IRedisConnectionFactory, RedisConnectionFactory>();
            services.AddSingleton<Helper>();
            services.AddMvc(op => op.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ABTS API", Version = "v1" });
            });

            services.AddCors();
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
            app.UseCors(opt => opt.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ABTS API V1");
            });
        }
    }
}
