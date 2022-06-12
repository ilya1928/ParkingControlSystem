using System;
using Xamarin.Essentials;

namespace ParkingControl.Mobile.Models
{
    public class ReportingRequest
    {
        public Guid ReportId { get; set; }
        public FileResult Panorama { get; set; }
        public FileResult LicensePlate { get; set; }
        public Database.Models.Location Location { get; set; }
        public string AdditionalInfo { get; set; }
    }
}
