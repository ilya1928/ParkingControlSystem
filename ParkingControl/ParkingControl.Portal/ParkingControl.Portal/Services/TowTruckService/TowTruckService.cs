using Microsoft.EntityFrameworkCore;
using ParkingControl.Database;
using ParkingControl.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingControl.Portal.Services
{
    public class TowTruckService : ITowTruckService
    {
        private readonly ApplicationDbContext context;

        public TowTruckService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TowTruck>> GetTowTrucksAsync()
        {
            return await context.TowTrucks
                .Include(tt => tt.TowTruckReportVehicleTypes).ThenInclude(ttrvt => ttrvt.ReportVehicleType)
                .ToListAsync();
        }
    }
}
