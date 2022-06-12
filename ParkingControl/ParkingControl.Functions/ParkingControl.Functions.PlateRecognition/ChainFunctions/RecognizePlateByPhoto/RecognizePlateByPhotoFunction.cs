using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using ParkingControl.Functions.PlateRecognition.ChainFunctions.RecognizePlateByPhoto.Services;
using ParkingControl.Functions.PlateRecognition.Constants;
using System;
using System.Threading.Tasks;

namespace ParkingControl.Functions.PlateRecognition
{
    public class RecognizePlateByPhotoFunction
    {
        private readonly IPlateRecognitionService plateRecognitionService;
        private readonly IBlobStorageService blobStorageService;

        public RecognizePlateByPhotoFunction(IPlateRecognitionService plateRecognitionService,
            IBlobStorageService blobStorageService)
        {
            this.plateRecognitionService = plateRecognitionService;
            this.blobStorageService = blobStorageService;
        }

        [FunctionName(FunctionConstants.RecognizePlateByPhoto)]
        public async Task<string> RecognizePlateByPhoto([ActivityTrigger] Guid plateBlobName)
        {
            var plateBlobUrl = blobStorageService.GetPlateBlobUrlByName(plateBlobName.ToString());
            var plateNumber = await plateRecognitionService.RecognizeUrlAsync(plateBlobUrl);
            return plateNumber;
        }
    }
}