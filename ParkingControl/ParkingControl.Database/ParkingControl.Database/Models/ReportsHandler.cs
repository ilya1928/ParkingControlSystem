using System;
using System.Collections.Generic;

namespace ParkingControl.Database.Models
{
    public class ReportsHandler
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string ImageUri { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<Report> Reports { get; set; }
        public IEnumerable<ReportsHandlerDistrict> ReportsHandlerDistricts { get; set; }
    }
}
