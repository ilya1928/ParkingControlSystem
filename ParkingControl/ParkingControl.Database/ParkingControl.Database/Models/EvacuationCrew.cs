using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingControl.Database.Models
{
    public class EvacuationCrew
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }

        public Guid? TowTruckId { get; set; }
        public TowTruck TowTruck { get; set; }

        public int AppointedReports { get => Reports.Count(); }

        public IEnumerable<Report> Reports { get; set; }
        public IEnumerable<EvacuationCrewmate> EvacuationCrewmates { get; set; }
        public IEnumerable<EvacuationCrewDistrict> EvacuationCrewDistricts { get; set; }
    }
}
