using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WeatherHub.AccuWeather
{
    public class AccuWeatherWeatherProvider : WeatherHub.IWeatherProvider
    {
        public string ApiKey { get; }

        public AccuWeatherWeatherProvider(string apiKey)
        {
            this.ApiKey = apiKey;
        }

        public async Task<WeatherResult> GetWeatherAsync(string city, string countryCode)
        {
            var locations = await GetLocationsAsync(city, countryCode);

            var location = locations.FirstOrDefault();

            if (location == null)
            {
                throw new InvalidOperationException("Unknown location!");
            }

            string url = $"http://dataservice.accuweather.com/forecasts/v1/hourly/1hour/{location.Key}?apikey={ApiKey}";

            string json = await GetJsonAsync(url);

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<TemperatureResult>>(json);

            return result.Select(x => x.ToWeatherResult(location)).FirstOrDefault();
        }

        private async Task<LocationResult[]> GetLocationsAsync(string city, string countryCode)
        {
            city = WebUtility.UrlEncode(city);
            countryCode = WebUtility.UrlEncode(countryCode);

            string url = $"http://dataservice.accuweather.com/locations/v1/cities/{countryCode}/search?apikey={this.ApiKey}&q={city}";

            string json = await GetJsonAsync(url);

            List<LocationResult> locations = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LocationResult>>(json);

            return locations.ToArray();
        }


        static async Task<string> GetJsonAsync(string url)
        {
            using (var webClient = new WebClient())
            {
                return await webClient.DownloadStringTaskAsync(url);
            }
        }

    }
}
