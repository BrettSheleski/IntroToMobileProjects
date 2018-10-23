using OpenWeatherMap.Standard;
using System;
using System.Threading.Tasks;
using WeatherHub.OpenWeatherMap.Extensions;

namespace WeatherHub.OpenWeatherMap
{
    public class OpenWeatherMapProvider : WeatherHub.IWeatherProvider
    {
        public OpenWeatherMapProvider(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        public string ApiKey { get; }

        public async Task<WeatherResult> GetWeatherAsync(string city, string stateCode, string countryCode)
        {
            var forecast = new Forecast();

            city = $"{city}, {stateCode}";

            var weather = await forecast.GetWeatherDataByCityNameAsync(ApiKey, city, countryCode);

            WeatherResult result = weather?.ToResult();

            return result;
        }
    }
}
