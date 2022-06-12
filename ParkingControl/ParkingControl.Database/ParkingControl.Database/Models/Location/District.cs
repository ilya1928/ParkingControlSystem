using System;
using System.Collections.Generic;

namespace ParkingControl.Database.Models
{
    public class District
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
    }
}
