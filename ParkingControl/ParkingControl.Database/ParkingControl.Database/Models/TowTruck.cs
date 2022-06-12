using System;
using System.Collections.Generic;

namespace ParkingControl.Database.Models
{
    public class TowTruck
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string GovernmentNumber { get; set; }

        public int MaxAcceptableWeight { get; set; }
        public int MaxAcceptableLength { get; set; }

        public EvacuationCrew EvacuationCrew { get; set; }

        public IEnumerable<TowTruckReportVehicleType> TowTruckReportVehicleTypes { get; set; }
    }
}
