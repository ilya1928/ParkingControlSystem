using ParkingControl.Database;
using ParkingControl.Database.Models;
using System.Threading.Tasks;

namespace ParkingControl.API.Services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext context;

        public ReportService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task CreateReportAsync(Report report)
        {
            await context.Reports.AddAsync(report);
            await context.SaveChangesAsync();
        }
    }
}
