using ParkingControl.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingControl.Mobile.Services.Location
{
    public class LocationsManager
    {
        readonly ILocationService locationService;

        public LocationsManager(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        public Task<IEnumerable<District>> GetDistrictsAsync()
        {
            return locationService.GetDistrictsAsync();
        }
    }
}
