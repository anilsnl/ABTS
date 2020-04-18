using System.Threading.Tasks;

namespace ABTS.HangfireService.Abtract
{
    public interface IElasticReorganizer
    {
        Task StartReocganizationAsync();
    }
}
