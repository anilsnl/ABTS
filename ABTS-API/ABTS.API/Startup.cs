using ABTS.BLL.IOC;
using ABTS.ElasticService.IOC;
using ABTS.RedisService.IOC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
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

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterBLL(Configuration);
            services.RegisterElasticSearchService(Configuration);
            services.RegisterRedisService(Configuration);

            services.AddMvc(op => op.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
                options.DefaultApiVersion = new ApiVersion(2, 0);
                options.UseApiBehavior = false;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "ABTS API", Version = "v2" });
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
            app.UseApiVersioning();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "ABTS API V2");
            });
        }
    }
}
