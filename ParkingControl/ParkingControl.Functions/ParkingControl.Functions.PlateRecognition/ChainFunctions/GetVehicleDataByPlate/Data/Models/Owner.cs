using System;
using System.Collections.Generic;

namespace ParkingControl.Functions.PlateRecognition.ChainFunctions.GetVehicleDataByPlate.Data.Models
{
    public class Owner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentificationNumber { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
