using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using ParkingControl.Functions.PlateRecognition.Constants;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Functions.PlateRecognition.ChainFunctions.RecognizePlateByPhoto.Services
{
    public class PlateRecognitionService : IPlateRecognitionService
    {
        private readonly ApiKeyServiceClientCredentials clientCredentials = new ApiKeyServiceClientCredentials
            (Environment.GetEnvironmentVariable(CognitiveServiceClientConstants.SubscriptionKey));

        private readonly string subscriptionEndpoint = Environment
            .GetEnvironmentVariable(CognitiveServiceClientConstants.SubscriptionEndpoint);

        private readonly int maxRetryTimes = 3;
        private readonly TimeSpan queryWaitTimeInSecond = TimeSpan.FromSeconds(3);

        public async Task<string> RecognizeUrlAsync(string imageUrl)
        {
            var textOperationResult = await RecognizeAsync(
                async (ComputerVisionClient client) => await client.RecognizeTextAsync(imageUrl, TextRecognitionMode.Printed),
                headers => headers.OperationLocation);

            var stringResult = ProcessTextOperationResult(textOperationResult);
            return stringResult;
        }

        private async Task<TextOperationResult> RecognizeAsync<T>(Func<ComputerVisionClient, Task<T>> GetHeadersAsyncFunc, Func<T, string> GetOperationUrlFunc) where T : new()
        {
            using var client = new ComputerVisionClient(clientCredentials) { Endpoint = subscriptionEndpoint };

            T recognizeHeaders = await GetHeadersAsyncFunc(client);
            string operationUrl = GetOperationUrlFunc(recognizeHeaders);
            string operationId = operationUrl.Substring(operationUrl.LastIndexOf('/') + 1);

            TextOperationResult result = await client.GetTextOperationResultAsync(operationId);
            for (int attempt = 1; attempt <= maxRetryTimes; attempt++)
            {
                if (result.Status == TextOperationStatusCodes.Failed || result.Status == TextOperationStatusCodes.Succeeded)
                {
                    break;
                }

                await Task.Delay(queryWaitTimeInSecond);
                result = await client.GetTextOperationResultAsync(operationId);
            }

            return result;
        }

        private string ProcessTextOperationResult(TextOperationResult textOperationResult)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (textOperationResult != null && textOperationResult.RecognitionResult != null &&
                textOperationResult.RecognitionResult.Lines != null && textOperationResult.RecognitionResult.Lines.Count > 0)
            {
                foreach (var line in textOperationResult.RecognitionResult.Lines)
                {
                    foreach (var word in line.Words)
                    {
                        stringBuilder.Append(word.Text);
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
}
