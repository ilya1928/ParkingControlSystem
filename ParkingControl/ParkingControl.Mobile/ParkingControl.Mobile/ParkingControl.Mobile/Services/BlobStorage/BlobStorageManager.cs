using ParkingControl.Mobile.Enums;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ParkingControl.Mobile.Services.BlobStorage
{
    public class BlobStorageManager
    {
        readonly IBlobStorageService blobStorageService;

        public BlobStorageManager(IBlobStorageService blobStorageService)
        {
            this.blobStorageService = blobStorageService;
        }

        public Task UploadPhotoAsync(PhotoType photoType, Guid reportId, FileResult image)
        {
            return blobStorageService.UploadPhotoAsync(photoType, reportId, image);
        }
    }
}
