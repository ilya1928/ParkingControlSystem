using ParkingControl.Shared.DTO.Report;
using System.Threading.Tasks;

namespace ParkingControl.Mobile.Services.Report
{
    public class ReportsManager
    {
        readonly IReportService reportService;

        public ReportsManager(IReportService reportService)
        {
            this.reportService = reportService;
        }

        public Task CreateReportAsync(CreateReportRequest createReportRequest)
        {
            return reportService.CreateReportAsync(createReportRequest);
        }
    }
}
