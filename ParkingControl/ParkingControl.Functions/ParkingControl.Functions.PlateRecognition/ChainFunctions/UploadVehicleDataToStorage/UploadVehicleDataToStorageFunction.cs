using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using ParkingControl.Database;
using ParkingControl.Database.Models;
using ParkingControl.Functions.PlateRecognition.Constants;
using System.Threading.Tasks;

namespace ParkingControl.Functions.PlateRecognition
{
    public class UploadVehicleDataToStorageFunction
    {
        private readonly ApplicationDbContext context;

        public UploadVehicleDataToStorageFunction(ApplicationDbContext context)
        {
            this.context = context;
        }

        [FunctionName(FunctionConstants.UploadVehicleDataToStorage)]
        public async Task UploadVehicleDataToStorage([ActivityTrigger] ReportVehicle reportVehicle)
        {
            await context.ReportVehicles.AddAsync(reportVehicle);
            await context.SaveChangesAsync();
        }
    }
}