using Microsoft.EntityFrameworkCore;
using ParkingControl.Database;
using ParkingControl.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingControl.Portal.Services
{
    public class EvacuationCrewmateService : IEvacuationCrewmateService
    {
        private readonly ApplicationDbContext context;

        public EvacuationCrewmateService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<EvacuationCrewmate>> GetEvacuationCrewmatesAsync()
        {
            return await context.EvacuationCrewmates
                .Include(ec => ec.ApplicationUser)
                .ToListAsync();
        }
    }
}
