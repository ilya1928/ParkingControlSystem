using ParkingControl.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingControl.Mobile.Services.Location
{
    public interface ILocationService
    {
        Task<IEnumerable<District>> GetDistrictsAsync();
    }
}
