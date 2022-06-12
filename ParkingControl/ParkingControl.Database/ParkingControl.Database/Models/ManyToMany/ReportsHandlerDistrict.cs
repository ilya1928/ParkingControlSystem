using System;

namespace ParkingControl.Database.Models
{
    public class ReportsHandlerDistrict
    {
        public Guid ReportsHandlerId { get; set; }
        public ReportsHandler ReportsHandler { get; set; }

        public Guid DistrictId { get; set; }
        public District District { get; set; }
    }
}
