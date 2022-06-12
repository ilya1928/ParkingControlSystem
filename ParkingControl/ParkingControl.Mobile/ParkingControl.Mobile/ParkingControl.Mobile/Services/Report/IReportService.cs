using ParkingControl.Shared.DTO.Report;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Mobile.Services.Report
{
    public interface IReportService
    {
        Task CreateReportAsync(CreateReportRequest createReportRequest);
    }
}
