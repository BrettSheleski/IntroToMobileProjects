using System;
using Plugin.Geolocator;
using System.Threading.Tasks;

namespace GpsDemo.Droid
{
    public class AndroidLocationService : ILocationService
    {

        public async Task<Location> GetLocationAsync(){

            var locator = CrossGeolocator.Current;

            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            return new Location()
            {
                Latitude = position.Latitude,
                Longitude = position.Longitude
            };
        }

    }
}
