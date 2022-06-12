using System.IO;
using System.Threading.Tasks;

namespace ParkingControl.Functions.PlateRecognition.ChainFunctions.RecognizePlateByPhoto.Services
{
    public interface IBlobStorageService
    {
        Task<Stream> GetPlateBlobByName(string blobName);
        string GetPlateBlobUrlByName(string blobName);
    }
}
