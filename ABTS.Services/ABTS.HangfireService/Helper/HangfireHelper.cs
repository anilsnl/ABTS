using ABTS.HangfireService.Abtract;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ABTS.HangfireService.Helper
{
    public static class HangfireHelper
    {
        public static void RegisterJobs(IServiceScopeFactory serviceScopeFactory)
        {
            RecurringJob.AddOrUpdate<IElasticReorganizer>(a=>a.StartReocganizationAsync(),
                "0 0 * * *", //this cron expressions means execute at 00:00 am. more info: "https://crontab.guru/#0_0_*_*_*"
                TimeZoneInfo.Utc);
        }
    }
}
