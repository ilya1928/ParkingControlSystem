using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ParkingControl.Database;
using ParkingControl.Database.Models;
using ParkingControl.Portal.Configuration;
using ParkingControl.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Portal.Services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext context;
        private readonly BlobStorageConfiguration blobStorageConfiguration;

        public ReportService(ApplicationDbContext context,
            IOptions<BlobStorageConfiguration> blobStorageConfigOptions)
        {
            this.context = context;
            blobStorageConfiguration = blobStorageConfigOptions.Value;
        }

        public async Task<IEnumerable<Report>> GetReportsAsync(string handlerName)
        {
            return await context.Reports
                .AsNoTracking()
                .Include(r => r.Location).ThenInclude(l => l.Address)
                .Where(r => r.ReportsHandler.ApplicationUser.UserName.Equals(handlerName))
                .ToListAsync();
        }

        public async Task<Report> GetReportByIdAsync(Guid reportId)
        {
            return await context.Reports
                .AsNoTracking()
                .Where(r => r.Id == reportId)
                .Include(r => r.ReportVehicle)
                .Include(r => r.Location).ThenInclude(l => l.Address)
                .SingleOrDefaultAsync();
        }

        public string GetReportPanoramaLink(Guid reportId)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(blobStorageConfiguration.PanoramasLink);
            stringBuilder.Append(reportId);
            stringBuilder.Append(blobStorageConfiguration.JpegExtension);

            return stringBuilder.ToString();
        }

        public async Task<EvacuationDetails> GetEvacuationDetails(Guid reportId)
        {
            var evacuationDetails = await context.Reports
                .AsNoTracking()
                .Include(r => r.ReportVehicle)
                .Include(r => r.Location).ThenInclude(r => r.Address)
                .Where(r => r.Id == reportId)
                .Select(report => new EvacuationDetails
                { 
                    VehicleLength = report.ReportVehicle.Length,
                    VehicleWeight = report.ReportVehicle.Weight,
                    VehicleType = report.ReportVehicle.VehicleTypeName,
                    DistrictId = report.Location.Address.DistrictId
                })
                .SingleOrDefaultAsync();

            return evacuationDetails;
        }

        public async Task AssignReportToCrew(Guid reportId, Guid evacuationCrewId)
        {
            var report = new Report
            {
                Id = reportId,
                IsApproved = true,
                IsProcessed = true,
                EvacuationCrewId = evacuationCrewId
            };

            context.Reports.Attach(report);
            context.Entry(report).Property(r => r.IsApproved).IsModified = true;
            context.Entry(report).Property(r => r.IsProcessed).IsModified = true;
            context.Entry(report).Property(r => r.EvacuationCrewId).IsModified = true;

            await context.SaveChangesAsync();
            context.Entry(report).State = EntityState.Detached;
        }

        public async Task AddRejectionReasonToReport(Guid reportId, string rejectionReason)
        {
            var report = new Report
            {
                Id = reportId,
                RejectionReason = rejectionReason,
                IsApproved = false,
                IsProcessed = true,
                EvacuationCrewId = null
            };

            context.Reports.Attach(report);
            context.Entry(report).Property(r => r.RejectionReason).IsModified = true;
            context.Entry(report).Property(r => r.IsApproved).IsModified = true;
            context.Entry(report).Property(r => r.IsProcessed).IsModified = true;
            context.Entry(report).Property(r => r.EvacuationCrewId).IsModified = true;

            await context.SaveChangesAsync();
            context.Entry(report).State = EntityState.Detached;
        }
    }
}
