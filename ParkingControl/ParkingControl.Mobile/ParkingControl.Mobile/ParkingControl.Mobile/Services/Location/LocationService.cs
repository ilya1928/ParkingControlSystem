using ParkingControl.Database.Models;
using ParkingControl.Shared.Constants;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ParkingControl.Mobile.Services.Location
{
    public class LocationService : ILocationService
    {
        readonly HttpClient client;

        public LocationService()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<District>> GetDistrictsAsync()
        {
            var uri = new Uri(string.Format(ApiRoutes.BaseUrl, ApiRoutes.LocationController, ApiRoutes.GetDistricts));

            var response = await client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }

            string content = await response.Content.ReadAsStringAsync();
            var districts = JsonSerializer.Deserialize<List<District>>(content);

            return districts;
        }
    } 
}
