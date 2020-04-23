using ABTS.CitizenshipVerificationService.Enums;
using ABTS.CitizenshipVerificationService.Models;
using System.Threading.Tasks;

namespace ABTS.CitizenshipVerificationService.Abstract
{
    public interface ICitizenshipVerificationServiceManager
    {
        Task<bool> IsServiceAviliableAsync();
        Task<CitizenshipVerificationResult> VerifyAsync(Person person);
    }
}
