using System;

namespace ParkingControl.Shared.DTO.Report
{
    public class CreateReportRequest
    {
        public Guid Id { get; set; }

        public DateTime ReportedDate { get; set; }
        public string AdditionalInfo { get; set; }
        public Guid LocationId { get; set; }
    }
}
