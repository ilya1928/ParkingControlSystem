using System;

namespace ParkingControl.Functions.PlateRecognition.ChainFunctions.GetVehicleDataByPlate.Data.Models
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string GovernmentNumber { get; set; }
        public string Model { get; set; }

        public int Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }

        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }

        public Guid VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
