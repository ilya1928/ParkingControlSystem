using ParkingControl.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingControl.Portal.Services
{
    public interface IEvacuationCrewmateService
    {
        Task<IEnumerable<EvacuationCrewmate>> GetEvacuationCrewmatesAsync();
    }
}
