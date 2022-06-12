using ParkingControl.Shared.Constants;
using ParkingControl.Shared.DTO.Report;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ParkingControl.Mobile.Services.AzureFunction
{
    public class AzureFunctionService : IAzureFunctionService
    {
        readonly HttpClient client;

        public AzureFunctionService()
        {
            client = new HttpClient();
        }
        public async Task TriggerPlateRecognitionAsync(Guid reportId)
        {
            var uri = new Uri(FunctionRoutes.PlateRecognitionTrigger);

            var blobdetails = new LicensePlateBlobDetails(reportId);
            string json = JsonSerializer.Serialize(blobdetails);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }
    }
}
