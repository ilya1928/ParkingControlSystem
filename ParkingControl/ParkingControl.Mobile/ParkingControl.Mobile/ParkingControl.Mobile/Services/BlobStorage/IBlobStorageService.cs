using ParkingControl.Mobile.Enums;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ParkingControl.Mobile.Services.BlobStorage
{
    public interface IBlobStorageService
    {
        Task UploadPhotoAsync(PhotoType photoType, Guid reportId, FileResult image);
    }
}
