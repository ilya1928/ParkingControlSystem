using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.EntityFrameworkCore;
using ParkingControl.Functions.PlateRecognition.ChainFunctions.GetVehicleDataByPlate.Data;
using ParkingControl.Functions.PlateRecognition.ChainFunctions.GetVehicleDataByPlate.Data.Models;
using ParkingControl.Functions.PlateRecognition.Constants;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingControl.Functions.PlateRecognition
{
    public class GetVehicleDataByPlateFunction
    {
        private readonly VehicleStorageContext context;

        public GetVehicleDataByPlateFunction(VehicleStorageContext context)
        {
            this.context = context;
        }

        [FunctionName(FunctionConstants.GetVehicleDataByPlate)]
        public async Task<Vehicle> GetVehicleDataByPlateAsync([ActivityTrigger] string plateNumber)
        {
            var vehicleInfo = await context.Vehicles
                .Include(v => v.Owner)
                .Include(v => v.VehicleType)
                .Where(v => v.GovernmentNumber.Equals(plateNumber))
                .SingleOrDefaultAsync();

            return vehicleInfo;
        }
    }
}