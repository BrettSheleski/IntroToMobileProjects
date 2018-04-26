using System;
using CoreLocation;
using UIKit;
using System.Threading.Tasks;
using Plugin.Geolocator;

namespace GpsDemo.iOS
{
    public class IosLocationService : ILocationService
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
