using ParkingControl.Shared.Constants;
using ParkingControl.Shared.DTO.Report;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ParkingControl.Mobile.Services.Report
{
    public class ReportService : IReportService
    {
        readonly HttpClient client;

        public ReportService()
        {
            client = new HttpClient();
        }

        public async Task CreateReportAsync(CreateReportRequest createReportRequest)
        {
            var uri = new Uri(string.Format(ApiRoutes.BaseUrl, ApiRoutes.ReportController, string.Empty));

            string json = JsonSerializer.Serialize(createReportRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(uri, content);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }
    }
}
