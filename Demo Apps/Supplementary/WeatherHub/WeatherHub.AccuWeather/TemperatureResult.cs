using System;

namespace WeatherHub.AccuWeather
{
    public class TemperatureResult
    {
        public DateTime DateTime { get; set; }
        public int EpochDateTime { get; set; }
        public int WeatherIcon { get; set; }
        public string IconPhrase { get; set; }
        public bool IsDaylight { get; set; }
        public Temperature Temperature { get; set; }
        public int PrecipitationProbability { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }

        internal WeatherResult ToWeatherResult(LocationResult location, WindSpeed windSpeed)
        {
            return new WeatherResult(new DegreesFahrenheit(this.Temperature.Value), new LatitudeLongitude(location.GeoPosition.Latitude, location.GeoPosition.Longitude), windSpeed);
        }
    }
}
