using AutoMapper;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ParkingControl.Database.Models;
using ParkingControl.Functions.PlateRecognition.ChainFunctions.GetVehicleDataByPlate.Data.Models;
using ParkingControl.Functions.PlateRecognition.Constants;
using ParkingControl.Shared.DTO.Report;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkingControl.Functions.PlateRecognition
{
    public class PlateRecognitionOrchestrator
    {
        private readonly IMapper mapper;

        public PlateRecognitionOrchestrator(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [FunctionName("PlateRecognitionOrchestrator")]
        public async Task RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var requestContent = context.GetInput<string>();
            var plateBlobDetails = JsonConvert.DeserializeObject<LicensePlateBlobDetails>(requestContent);

            var recognizedPlate = await context
                .CallActivityAsync<string>(FunctionConstants.RecognizePlateByPhoto, plateBlobDetails.Name);

            var vehicle = await context
                .CallActivityAsync<Vehicle>(FunctionConstants.GetVehicleDataByPlate, recognizedPlate);

            var reportVehicle = mapper.Map<ReportVehicle>(vehicle);
            reportVehicle.ReportId = plateBlobDetails.Name;

            await context.CallActivityAsync(FunctionConstants.UploadVehicleDataToStorage, reportVehicle);
        }

        [FunctionName("PlateRecognitionOrchestrator_HttpTriggerStart")]
        public async Task<HttpResponseMessage> HttpStart(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestMessage request,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
        {
            var requestContent = await request.Content.ReadAsStringAsync();
            string instanceId = await starter
                .StartNewAsync("PlateRecognitionOrchestrator", input: requestContent);

            log.LogInformation($"Started orchestration with ID = '{instanceId}'.");
            return starter.CreateCheckStatusResponse(request, instanceId);
        }
    }
}