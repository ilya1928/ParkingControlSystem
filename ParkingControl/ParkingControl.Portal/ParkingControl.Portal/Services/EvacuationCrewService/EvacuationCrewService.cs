using Microsoft.EntityFrameworkCore;
using ParkingControl.Database;
using ParkingControl.Database.Models;
using ParkingControl.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingControl.Portal.Services
{
    public class EvacuationCrewService : IEvacuationCrewService
    {
        private readonly ApplicationDbContext context;

        public EvacuationCrewService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<EvacuationCrew> GetEvacuationCrewAsync(Guid id)
        {
            return await context.EvacuationCrews
                .Include(ec => ec.EvacuationCrewmates)
                .Include(ec => ec.TowTruck).ThenInclude(tt => tt.TowTruckReportVehicleTypes)
                .Include(ec => ec.EvacuationCrewDistricts).ThenInclude(ec => ec.District)
                .FirstOrDefaultAsync(ec => ec.Id == id);
        }

        public async Task<IEnumerable<EvacuationCrew>> GetEvacuationCrewsAsync()
        {
            return await context.EvacuationCrews
                .Include(ec => ec.EvacuationCrewmates)
                .Include(ec => ec.TowTruck).ThenInclude(tt => tt.TowTruckReportVehicleTypes)
                .Include(ec => ec.EvacuationCrewDistricts).ThenInclude(ec => ec.District)
                .Include(ec => ec.Reports)
                .ToListAsync();
        }

        public async Task CreateEvacuationCrewAsync(EvacuationCrew evacuationCrew, IEnumerable<Guid> districtIds)
        {
            await context.EvacuationCrews.AddAsync(evacuationCrew);

            var evacuationCrewDistricts = new List<EvacuationCrewDistrict>();

            foreach (var districtId in districtIds)
            {
                evacuationCrewDistricts.Add(
                    new EvacuationCrewDistrict
                    {
                        EvacuationCrewId = evacuationCrew.Id,
                        DistrictId = districtId
                    });
            }

            await context.EvacuationCrewDistricts.AddRangeAsync(evacuationCrewDistricts);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EvacuationCrew>> GetSuitableCrewAsync
            (EvacuationDetails evacuationDetails)
        {
            var crews = await context.EvacuationCrews
                .AsNoTracking()
                .Include(ec => ec.Reports)
                .Include(ec => ec.EvacuationCrewDistricts)
                .Include(ec => ec.TowTruck)
                    .ThenInclude(tt => tt.TowTruckReportVehicleTypes)
                    .ThenInclude(ttrvt => ttrvt.ReportVehicleType)
                .Where(ec => ec.IsAvailable &&
                    ec.TowTruck.MaxAcceptableLength > evacuationDetails.VehicleLength &&
                    ec.TowTruck.MaxAcceptableWeight > evacuationDetails.VehicleWeight)
                .ToListAsync();

            crews.Select(c =>
                c.EvacuationCrewDistricts.Select(ecd => ecd.DistrictId)
                    .Contains(evacuationDetails.DistrictId) &&
                c.TowTruck.TowTruckReportVehicleTypes.Select(ttrvt => ttrvt.ReportVehicleType.Name)
                    .Contains(evacuationDetails.VehicleType));

            return crews;
        }
    }
}
