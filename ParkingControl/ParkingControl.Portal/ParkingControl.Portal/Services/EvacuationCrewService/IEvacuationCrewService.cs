using ParkingControl.Database.Models;
using ParkingControl.Portal.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingControl.Portal.Services
{
    public interface IEvacuationCrewService
    {
        Task<IEnumerable<EvacuationCrew>> GetEvacuationCrewsAsync();
        Task<EvacuationCrew> GetEvacuationCrewAsync(Guid id);
        Task<IEnumerable<EvacuationCrew>> GetSuitableCrewAsync(EvacuationDetails evacuationDetails);
        Task CreateEvacuationCrewAsync(EvacuationCrew evacuationCrew, IEnumerable<Guid> districtIds);
    }
}
