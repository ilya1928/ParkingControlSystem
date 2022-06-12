using System;

namespace ParkingControl.Portal.Models
{
    public class EvacuationDetails
    {
        public int VehicleLength { get; set; }
        public int VehicleWeight { get; set; }
        public string VehicleType { get; set; }
        public Guid DistrictId { get; set; }
    }
}
