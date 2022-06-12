using AutoMapper;
using ParkingControl.Database.Models;
using ParkingControl.Functions.PlateRecognition.ChainFunctions.GetVehicleDataByPlate.Data.Models;

namespace ParkingControl.Functions.PlateRecognition.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Vehicle, ReportVehicle>();
        }
    }
}
