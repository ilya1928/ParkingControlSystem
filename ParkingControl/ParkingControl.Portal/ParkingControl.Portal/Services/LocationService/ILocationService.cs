using ParkingControl.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingControl.Portal.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<District>> GetDistrictsAsync();
    }
}
