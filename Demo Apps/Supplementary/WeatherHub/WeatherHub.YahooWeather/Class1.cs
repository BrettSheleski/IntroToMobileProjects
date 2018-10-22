using System;
using System.Threading.Tasks;

namespace WeatherHub.YahooWeather
{
    public class YahooWeatherWeatherProvider : IWeatherProvider
    {
        public Task<WeatherResult> GetWeatherAsync(string city, string countryCode)
        {
            
        }
    }
}
