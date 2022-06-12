using System.Threading.Tasks;

namespace ParkingControl.Functions.PlateRecognition.ChainFunctions.RecognizePlateByPhoto.Services
{
    public interface IPlateRecognitionService
    {
        Task<string> RecognizeUrlAsync(string imageUrl);
    }
}
