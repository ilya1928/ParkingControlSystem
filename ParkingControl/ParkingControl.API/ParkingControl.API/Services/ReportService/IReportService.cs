using ParkingControl.Database.Models;
using System.Threading.Tasks;

namespace ParkingControl.API.Services
{
    public interface IReportService
    {
        Task CreateReportAsync(Report report);
    }
}
