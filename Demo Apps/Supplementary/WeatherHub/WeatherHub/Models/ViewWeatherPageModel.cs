using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherHub.Models
{
    public class ViewWeatherPageModel : ModelBase
    {
        public ViewWeatherPageModel(IWeatherProvider weatherProvider)
        {
            this._weatherProvider = weatherProvider;
        }

        private string _city, _state, _country;

        public string City { get => _city; set { _city = value; OnPropertyChanged(); } }
        public string State { get => _state; set { _state = value; OnPropertyChanged(); } }
        public string Country { get => _country; set { _country = value; OnPropertyChanged(); } }

        IWeatherProvider _weatherProvider { get; }

        public Task<WeatherResult> GetWeather()
        {
            return _weatherProvider.GetWeatherAsync($"{City}, {State}", Country);
        }
    }
}
