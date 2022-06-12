using Azure.Storage.Blobs;
using ParkingControl.Functions.PlateRecognition.Constants;
using ParkingControl.Shared.Constants;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Functions.PlateRecognition.ChainFunctions.RecognizePlateByPhoto.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobServiceClient blobServiceClient;

        public BlobStorageService(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }

        public async Task<Stream> GetPlateBlobByName(string blobName)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(StorageContainers.LicensePlates);

            if(await containerClient.ExistsAsync())
            {
                var blobClient = containerClient.GetBlobClient(blobName);

                if(await blobClient.ExistsAsync()) 
                {
                    var blob = await blobClient.OpenReadAsync();
                    return blob;
                }
            }

            return null;
        }

        public string GetPlateBlobUrlByName(string blobName)
        {
            var storageUrl = Environment.GetEnvironmentVariable(ConfigurationConstants.LicensePlatesStorageUrl);

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(storageUrl);
            stringBuilder.Append(blobName);
            stringBuilder.Append(".jpg");

            return stringBuilder.ToString();
        }
    }
}
