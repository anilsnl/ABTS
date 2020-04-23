using ABTS.CitizenshipVerificationService.Abstract;
using ABTS.CitizenshipVerificationService.Enums;
using ABTS.CitizenshipVerificationService.Models;
using KPSPublic;
using System;
using System.Threading.Tasks;

namespace ABTS.CitizenshipVerificationService.Concrete
{
    public class CitizenshipVerificationServiceManager : ICitizenshipVerificationServiceManager
    {
        public async Task<bool> IsServiceAviliableAsync()
        {
            try
            {
                var client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap12);
                await client.OpenAsync();
                var res = client.State == System.ServiceModel.CommunicationState.Opened;
                await client.CloseAsync();
                return res;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CitizenshipVerificationResult> VerifyAsync(Person person)
        {
            try
            {
                var client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap12);
                await client.OpenAsync();
                if (client.State == System.ServiceModel.CommunicationState.Opened)
                {
                    var operationResult = await client
                        .TCKimlikNoDogrulaAsync(person.TurkishIdentityNumber,
                                                person.FirstName,
                                                person.LastName,
                                                person.BirthOfYear);
                    await client.CloseAsync();
                    return operationResult.Body.TCKimlikNoDogrulaResult ? CitizenshipVerificationResult.Verified : CitizenshipVerificationResult.NotVerified;
                }
                throw new Exception("Service could not be started.");
            }
            catch (Exception)
            {
                return CitizenshipVerificationResult.Error; ;
            }
        }
    }
}
