using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ParkingControl.Database;
using ParkingControl.Database.Models;
using ParkingControl.Portal.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingControl.Portal.Services
{
    public class ReportsHandlerService : IReportsHandlerService
    {
        private readonly ApplicationDbContext context;
        private readonly BlobStorageConfiguration blobStorageConfiguration;
        private readonly IProfileImageService profileImageService;

        public ReportsHandlerService(ApplicationDbContext context,
            IOptions<BlobStorageConfiguration> blobStorageConfigOptions, IProfileImageService profileImageService)
        {
            this.context = context;
            blobStorageConfiguration = blobStorageConfigOptions.Value;
            this.profileImageService = profileImageService;
        }

        public async Task<ReportsHandler> GetReportsHandlerAsync(string name)
        {
            return await context.ReportsHandlers
                .Include(rh => rh.ApplicationUser)
                .Include(rh => rh.Reports)
                .Include(rh => rh.ReportsHandlerDistricts).ThenInclude(rhd => rhd.District)
                .FirstOrDefaultAsync(rh => rh.ApplicationUser.UserName.Equals(name));
        }

        public async Task<ReportsHandler> GetReportsHandlerAsync(Guid id)
        {
            return await context.ReportsHandlers
                .Include(rh => rh.ApplicationUser)
                .Include(rh => rh.Reports)
                .Include(rh => rh.ReportsHandlerDistricts).ThenInclude(rhd => rhd.District)
                .FirstOrDefaultAsync(rh => rh.Id == id);
        }

        public async Task<IEnumerable<ReportsHandler>> GetReportsHandlersAsync()
        {
            return await context.ReportsHandlers
                .Include(rh => rh.ApplicationUser)
                .Include(rh => rh.Reports)
                .Include(rh => rh.ReportsHandlerDistricts).ThenInclude(rhd => rhd.District)
                .ToListAsync();
        }

        public async Task CreateReportsHandlerAsync(ReportsHandler reportsHandler, IEnumerable<Guid> districtIds)
        {
            await context.ReportsHandlers.AddAsync(reportsHandler);

            var reportsHandlerDistricts = new List<ReportsHandlerDistrict>();

            foreach (var districtId in districtIds)
            {
                reportsHandlerDistricts.Add(
                    new ReportsHandlerDistrict
                    {
                        ReportsHandlerId = reportsHandler.Id,
                        DistrictId = districtId
                    });
            }

            await context.ReportsHandlerDistricts.AddRangeAsync(reportsHandlerDistricts);
            await context.SaveChangesAsync();
        }

        public async Task UpdateReportsHandlerAsync(ReportsHandler reportsHandler, IEnumerable<Guid> districtIds)
        {
            context.ReportsHandlers.Update(reportsHandler);

            var currentReportsHandlerDistricts = context.ReportsHandlerDistricts.Where(rhd => rhd.ReportsHandlerId == reportsHandler.Id);
            context.ReportsHandlerDistricts.RemoveRange(currentReportsHandlerDistricts);

            var newReportsHandlerDistricts = new List<ReportsHandlerDistrict>();

            foreach(var districtId in districtIds)
            {
                newReportsHandlerDistricts.Add(
                    new ReportsHandlerDistrict
                    {
                        ReportsHandlerId = reportsHandler.Id,
                        DistrictId = districtId
                    });
            }

            await context.ReportsHandlerDistricts.AddRangeAsync(newReportsHandlerDistricts);
            await context.SaveChangesAsync();
        }

        public async Task<string> UpdateProfileImageLinkAsync(Guid fileId, Guid reportsHandlerId)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(blobStorageConfiguration.ProfileImagesLink);
            stringBuilder.Append(fileId.ToString());
            stringBuilder.Append(blobStorageConfiguration.JpegExtension);

            var imageLink = stringBuilder.ToString();

            var reportsHandler = await context.ReportsHandlers.FirstOrDefaultAsync(rh => rh.Id == reportsHandlerId);

            if(!reportsHandler.ImageUri.Equals(blobStorageConfiguration.NoProfileImageLink))
                await profileImageService.RemoveProfileImageAsync(reportsHandler.ImageUri);

            reportsHandler.ImageUri = imageLink;

            context.ReportsHandlers.Update(reportsHandler);
            await context.SaveChangesAsync();

            return imageLink;
        }

        public async Task RemoveProfileImageAsync(Guid reportsHandlerId)
        {
            var reportsHandler = await context.ReportsHandlers.FirstOrDefaultAsync(rh => rh.Id == reportsHandlerId);

            if (!reportsHandler.ImageUri.Equals(blobStorageConfiguration.NoProfileImageLink))
                await profileImageService.RemoveProfileImageAsync(reportsHandler.ImageUri);

            reportsHandler.ImageUri = blobStorageConfiguration.NoProfileImageLink;

            context.ReportsHandlers.Update(reportsHandler);
            await context.SaveChangesAsync();
        }
    }
}
