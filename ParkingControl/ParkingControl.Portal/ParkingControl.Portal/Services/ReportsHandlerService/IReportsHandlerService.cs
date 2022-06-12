using ParkingControl.Database.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkingControl.Portal.Services
{
    interface IReportsHandlerService
    {
        Task<ReportsHandler> GetReportsHandlerAsync(string name);
        Task<ReportsHandler> GetReportsHandlerAsync(Guid id);
        Task<IEnumerable<ReportsHandler>> GetReportsHandlersAsync();
        Task CreateReportsHandlerAsync(ReportsHandler reportsHandler, IEnumerable<Guid> districtIds);
        Task UpdateReportsHandlerAsync(ReportsHandler reportsHandler, IEnumerable<Guid> districtIds);
        Task<string> UpdateProfileImageLinkAsync(Guid fileId, Guid reportsHandlerId);
        Task RemoveProfileImageAsync(Guid reportsHandlerId);
    }
}
