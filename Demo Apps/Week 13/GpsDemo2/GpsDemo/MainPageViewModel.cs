using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace GpsDemo
{
    public class MainPageViewModel : ViewModel
    {
        private double latitude;
        private double longitude;

        public MainPageViewModel()
        {
            this.UpdateCommand = new Command(Update);
        }

        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
                OnPropertyChanged();
            }
        }
        public double Longitude { get => longitude; set => Set(ref longitude, value); }

        public Command UpdateCommand { get; }

        async void Update()
        {

            Location location = await Geolocation.GetLastKnownLocationAsync();

            this.Latitude = location?.Latitude ?? 0;
            this.Longitude = location?.Longitude ?? 0;

        }

    }
}
