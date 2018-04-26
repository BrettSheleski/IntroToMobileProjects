using Xamarin.Forms;
using System;

namespace GpsDemo
{
    public partial class GpsDemoPage : ContentPage
    {
        public GpsDemoPage()
        {
            InitializeComponent();

            locationService = GetLocationServiceSomehow();
        }

        ILocationService locationService;

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            // Get the location from the location service
            Location currentLocation = await locationService.GetLocationAsync();


            // Set the latitude and longitude to the labels
            LatitudeLabel.Text = currentLocation.Latitude.ToString();
            LongitudeLabel.Text = currentLocation.Longitude.ToString();
        }

        private ILocationService GetLocationServiceSomehow()
        {
            ILocationService mylocationService = DependencyService.Get<ILocationService>();

            return mylocationService;
        }
    }
}
