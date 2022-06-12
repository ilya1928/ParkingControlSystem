using System;

namespace ParkingControl.Database.Models
{
    public class EvacuationCrewDistrict
    {
        public Guid EvacuationCrewId { get; set; }
        public EvacuationCrew EvacuationCrew { get; set; }

        public Guid DistrictId { get; set; }
        public District District { get; set; }
    }
}
