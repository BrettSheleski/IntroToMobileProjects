using OpenWeatherMap.Standard;
using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherHub.OpenWeatherMap.Extensions
{
    public static class WeatherDataExtensions
    {
        public static WeatherResult ToResult(this WeatherData weatherData)
        {
            Kelvin kelvin = new Kelvin(weatherData.main.temp);

            LatitudeLongitude location = new LatitudeLongitude(weatherData.coord.lat, weatherData.coord.lon);

            WeatherResult result = new WeatherResult(kelvin, location);

            return result;
        }
    }
}
