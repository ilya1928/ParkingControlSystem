using System;

namespace ParkingControl.Shared.DTO.Report
{
    public class LicensePlateBlobDetails
    {
        public LicensePlateBlobDetails(Guid name)
        {
            Name = name;
        }

        public Guid Name { get; set; }
    }
}
