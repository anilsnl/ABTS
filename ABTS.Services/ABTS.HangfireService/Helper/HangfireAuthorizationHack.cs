using Hangfire.Dashboard;

namespace ABTS.HangfireService.Helper
{
    public class HangfireAuthorizationHack : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
}
