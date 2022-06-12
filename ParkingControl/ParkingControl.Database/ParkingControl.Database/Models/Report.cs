using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingControl.Database.Models
{
    public class Report
    {
        public Guid Id { get; set; }

        public DateTime ReportedDate { get; set; }
        public string AdditionalInfo { get; set; }

        public bool IsProcessed { get; set; }
        public bool IsApproved { get; set; }
        public bool IsCompleted { get; set; }
        public string RejectionReason { get; set; }

        [NotMapped]
        public string LocationString { get => this.Location.ToString(); }

        public ReportVehicle ReportVehicle { get; set; }

        public Guid? LocationId { get; set; }
        public Location Location { get; set; }

        public Guid? EvacuationCrewId { get; set; }
        public EvacuationCrew EvacuationCrew { get; set; }

        public Guid? ReportsHandlerId { get; set; }
        public ReportsHandler ReportsHandler { get; set; }
    }
}
