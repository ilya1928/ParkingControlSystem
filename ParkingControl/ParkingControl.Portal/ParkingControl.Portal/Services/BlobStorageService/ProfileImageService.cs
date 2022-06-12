using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using ParkingControl.Portal.Configuration;
using System;
using System.Threading.Tasks;

namespace ParkingControl.Portal.Services
{
    public class ProfileImageService : IProfileImageService
    {
        private readonly BlobStorageConfiguration blobStorageConfiguration;
        private readonly BlobServiceClient blobServiceClient;

        public ProfileImageService(IOptions<BlobStorageConfiguration> blobStorageConfigOptions, BlobServiceClient blobServiceClient)
        {
            this.blobStorageConfiguration = blobStorageConfigOptions.Value;
            this.blobServiceClient = blobServiceClient;
        }

        public async Task<Guid> UploadProfileImageAsync(IFormFile file)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(blobStorageConfiguration.ProfileImagesContainer);

            var fileId = Guid.NewGuid();
            var blobClient = containerClient.GetBlobClient(fileId.ToString());

            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream);
            }

            return fileId;
        }

        public async Task RemoveProfileImageAsync(string fileUrl)
        {
            var containerClient = blobServiceClient.GetBlobContainerClient(blobStorageConfiguration.ProfileImagesContainer);

            var fileName = fileUrl.Split("/")[^1];

            var blobClient = containerClient.GetBlobClient(fileName);

            if (await blobClient.ExistsAsync())
            {
                await blobClient.DeleteAsync();
            }
        }
    }
}
