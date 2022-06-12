using AutoMapper;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ParkingControl.Database;
using ParkingControl.Functions.PlateRecognition.ChainFunctions.GetVehicleDataByPlate.Data;
using ParkingControl.Functions.PlateRecognition.ChainFunctions.RecognizePlateByPhoto.Services;
using ParkingControl.Functions.PlateRecognition.Constants;
using ParkingControl.Functions.PlateRecognition.Mapper;
using System;

[assembly: FunctionsStartup(typeof(ParkingControl.Functions.PlateRecognition.Startup))]
namespace ParkingControl.Functions.PlateRecognition
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            string vehicleStorageConnectionString = Environment
                .GetEnvironmentVariable(ConfigurationConstants.VehicleStorageConnectionString);

            string parkingControlDbConnectionString = Environment
                .GetEnvironmentVariable(ConfigurationConstants.ParkingControlDbConnectionString);

            builder.Services.AddDbContext<VehicleStorageContext>(options =>
               SqlServerDbContextOptionsExtensions.UseSqlServer(options, vehicleStorageConnectionString));

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
               SqlServerDbContextOptionsExtensions.UseSqlServer(options, parkingControlDbConnectionString));

            builder.Services.AddScoped<IBlobStorageService, BlobStorageService>();
            builder.Services.AddScoped<IPlateRecognitionService, PlateRecognitionService>();

            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MapperProfile()));
            builder.Services.AddSingleton<IMapper>(service => new AutoMapper.Mapper(mapperConfig));

            builder.Services.AddHttpClient();
            builder.Services.AddLogging();
        }
    }
}
