using System;

namespace ParkingControl.Database.Models
{
    public class TowTruckReportVehicleType
    {
        public Guid TowTruckId { get; set; }
        public TowTruck TowTruck { get; set; }

        public Guid ReportVehicleTypeId { get; set; }
        public ReportVehicleType ReportVehicleType { get; set; }
    }
}
