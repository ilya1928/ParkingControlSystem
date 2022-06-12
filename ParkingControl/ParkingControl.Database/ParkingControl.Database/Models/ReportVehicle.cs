using System;

namespace ParkingControl.Database.Models
{
    public class ReportVehicle
    {
        public Guid Id { get; set; }

        public string GovernmentNumber { get; set; }
        public string Model { get; set; }

        public int Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }

        public string OwnerName { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string OwnerIdentificationNumber { get; set; }

        public string VehicleTypeName { get; set; }

        public Guid? ReportId { get; set; }
        public Report Report { get; set; }
    }
}
