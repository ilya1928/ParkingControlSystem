using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingControl.Portal.Services;
using System;
using System.Threading.Tasks;

namespace ParkingControl.Portal.Controllers
{
    [DisableRequestSizeLimit]
    public class UploadController : Controller
    {
        private readonly IProfileImageService profileImageService;

        public UploadController(IProfileImageService profileImageService)
        {
            this.profileImageService = profileImageService;
        }

        [HttpPost("upload/single")]
        public async Task<ActionResult<Guid>> Single(IFormFile file)
        {
            var fileId = await profileImageService.UploadProfileImageAsync(file);
            return fileId;
        }
    }
}
