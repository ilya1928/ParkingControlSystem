using System;
using System.Threading.Tasks;

namespace ParkingControl.Mobile.Services.AzureFunction
{
    public class AzureFunctionsManager
    {
        readonly IAzureFunctionService azureFunctionService;

        public AzureFunctionsManager(IAzureFunctionService azureFunctionService)
        {
            this.azureFunctionService = azureFunctionService;
        }

        public Task TriggerPlateRecognitionAsync(Guid reportId)
        {
            return azureFunctionService.TriggerPlateRecognitionAsync(reportId);
        }
    }
}
