using ParkingControl.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingControl.API.Services
{
    public interface ILocationService
    {
        Task<IEnumerable<District>> GetDistrictsAsync();
    }
}
