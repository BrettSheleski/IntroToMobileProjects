using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WhereIsMe
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            this.LocationService = DependencyService.Get<ILocationService>();
		}

        string latitudePlaceholderText, longitudePlaceholderText;

        public ILocationService LocationService { get; }

        private async void UpdateLocationButton_Clicked(object sender, EventArgs e)
        {
            var location = await LocationService.GetLocationAsync();

            this.UpdateLocationButton.IsEnabled = false;

            this.BindingContext = location;

            this.UpdateLocationButton.IsEnabled = true;
            this.ResetButton.IsEnabled = true;
        }

        private void ResetButton_Clicked(object sender, EventArgs e)
        {
            this.BindingContext = null;

            this.ResetButton.IsEnabled = false;
        }
    }
}
