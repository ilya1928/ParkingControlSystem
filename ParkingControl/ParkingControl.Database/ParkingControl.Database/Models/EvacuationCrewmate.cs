using System;

namespace ParkingControl.Database.Models
{
    public class EvacuationCrewmate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string ImageUri { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public Guid? EvacuationCrewId { get; set; }
        public EvacuationCrew EvacuationCrew { get; set; }
    }
}
