using ParkingControl.Database.Models;
using ParkingControl.Portal.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingControl.Portal.Services
{
    public interface IReportService
    {
        Task<IEnumerable<Report>> GetReportsAsync(string handlerName);
        Task<Report> GetReportByIdAsync(Guid reportId);
        string GetReportPanoramaLink(Guid reportId);
        Task<EvacuationDetails> GetEvacuationDetails(Guid reportId);
        Task AssignReportToCrew(Guid reportId, Guid evacuationCrewId);
        Task AddRejectionReasonToReport(Guid reportId, string rejectionReason);
    }
}
