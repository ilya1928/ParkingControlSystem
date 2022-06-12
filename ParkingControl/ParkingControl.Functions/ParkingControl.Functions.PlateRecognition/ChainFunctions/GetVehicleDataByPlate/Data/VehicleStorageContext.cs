using Microsoft.EntityFrameworkCore;
using ParkingControl.Functions.PlateRecognition.ChainFunctions.GetVehicleDataByPlate.Data.Models;

namespace ParkingControl.Functions.PlateRecognition.ChainFunctions.GetVehicleDataByPlate.Data
{
    public class VehicleStorageContext : DbContext
    {
        public VehicleStorageContext(DbContextOptions<VehicleStorageContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
    }
}
