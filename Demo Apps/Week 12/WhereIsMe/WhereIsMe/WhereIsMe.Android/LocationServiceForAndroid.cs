using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WhereIsMe.Droid
{
    public class LocationServiceForAndroid : ILocationService
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