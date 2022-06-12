using System;
using System.Collections.Generic;

namespace ParkingControl.Database.Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid DistrictId { get; set; }
        public District District { get; set; }

        public IEnumerable<Location> Locations { get; set; }
    }
}
