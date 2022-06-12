using Microsoft.EntityFrameworkCore;
using ParkingControl.Database;
using ParkingControl.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingControl.API.Services
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext context;

        public LocationService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<District>> GetDistrictsAsync()
        {
            return await context.Districts
                .Include(d => d.Addresses).ThenInclude(a => a.Locations)
                .ToListAsync();
        }
    }
}
