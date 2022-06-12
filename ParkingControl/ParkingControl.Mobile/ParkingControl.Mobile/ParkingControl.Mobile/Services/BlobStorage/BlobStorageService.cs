using Azure.Storage.Blobs;
using ParkingControl.Mobile.Enums;
using ParkingControl.Shared.Constants;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ParkingControl.Mobile.Services.BlobStorage
{
    public class BlobStorageService : IBlobStorageService
    {
        private const string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=stparkingcontrol;AccountKey=LW8nqhSvNhTtOTpOtbykWK/3cLqLHOH9qQ5RwQ8b2OYjqSxRjCTpOwGiymzz6IdaNnd/GW9TmrlZndw0gu7ZsQ==;EndpointSuffix=core.windows.net";

        public async Task UploadPhotoAsync(PhotoType photoType, Guid reportId, FileResult image)
        {
            var blobServiceClient = new BlobServiceClient(storageConnectionString);

            string containerName;

            switch (photoType)
            {
                case PhotoType.Panorama:
                    containerName = StorageContainers.Panoramas;
                    break;

                case PhotoType.LicensePlate:
                    containerName = StorageContainers.LicensePlates;
                    break;

                default:
                    return;
            }

            var container = blobServiceClient.GetBlobContainerClient(containerName);

            var blobClient = container.GetBlobClient(reportId.ToString());

            using var imageStream = await image.OpenReadAsync();
            await blobClient.UploadAsync(imageStream);
        }
    }
}
