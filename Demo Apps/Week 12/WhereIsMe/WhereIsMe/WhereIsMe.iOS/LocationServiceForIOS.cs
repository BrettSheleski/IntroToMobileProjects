using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace WhereIsMe.iOS
{
    public class LocationServiceForIOS : ILocationService
    {
        public Task<Location> GetLocationAsync()
        {
            return GetLocationAsync(CancellationToken.None);
        }

        public async Task<Location> GetLocationAsync(CancellationToken cancellationToken)
        {
            var locator = Plugin.Geolocator.CrossGeolocator.Current;
            locator.DesiredAccuracy = 100;

            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10), cancellationToken);

            return new Location(position.Latitude, position.Longitude);
        }
    }
}