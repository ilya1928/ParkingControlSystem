using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace ParkingControl.Portal.Services
{
    public interface IProfileImageService
    {
        Task<Guid> UploadProfileImageAsync(IFormFile file);
        Task RemoveProfileImageAsync(string fileUrl);
    }
}
