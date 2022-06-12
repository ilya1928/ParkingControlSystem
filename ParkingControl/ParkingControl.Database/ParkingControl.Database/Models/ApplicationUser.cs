using Microsoft.AspNetCore.Identity;

namespace ParkingControl.Database.Models
{
    public class ApplicationUser : IdentityUser
    {
        public EvacuationCrewmate EvacuationCrewmate { get; set; }
        public ReportsHandler ReportsHandler { get; set; }
    }
}
