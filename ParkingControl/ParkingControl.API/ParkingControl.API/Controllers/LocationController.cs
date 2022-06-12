using Microsoft.AspNetCore.Mvc;
using ParkingControl.API.Services;
using ParkingControl.Database.Models;
using ParkingControl.Shared.Constants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        [HttpGet(ApiRoutes.GetDistricts)]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<District>), 200)]
        public async Task<ActionResult<IEnumerable<District>>> GetDistrictsAsync()
        {
            var districts = await locationService.GetDistrictsAsync();
            return Ok(districts);
        }
    }
}
