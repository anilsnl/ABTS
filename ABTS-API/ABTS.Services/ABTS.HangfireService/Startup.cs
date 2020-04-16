using ABTS.DAL.IOC;
using ABTS.ElasticService.IOC;
using ABTS.HangfireService.Abtract;
using ABTS.HangfireService.Concrete;
using ABTS.HangfireService.Helper;
using Hangfire;
using Hangfire.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ABTS.HangfireService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterDataAccess(Configuration);
            services.RegisterElasticSearchService(Configuration);
            services.AddScoped<IElasticReorganizer, ElasticReorganizer>();
            #region Hangfire Registeration
            services.
                AddHangfire(x => x.UseRedisStorage(Configuration.GetConnectionString("HangfireRedis"), new RedisStorageOptions
                {
                    Prefix = "hg_",
                    ExpiryCheckInterval = TimeSpan.FromDays(365)
                }));
            services.AddHangfireServer();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseHangfireDashboard();
            app.UseHangfireServer();
            HangfireHelper.RegisterJobs(app.ApplicationServices.GetService<IServiceScopeFactory>());
        }
    }
}
