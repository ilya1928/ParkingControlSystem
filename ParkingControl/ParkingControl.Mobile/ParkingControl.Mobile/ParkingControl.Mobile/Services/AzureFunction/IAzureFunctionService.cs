using System;
using System.Threading.Tasks;

namespace ParkingControl.Mobile.Services.AzureFunction
{
    public interface IAzureFunctionService
    {
        Task TriggerPlateRecognitionAsync(Guid reportId);
    }
}
