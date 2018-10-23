using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WeatherHub.OpenWeatherMap.Tests
{
    [TestClass]
    public class OpenWeatherMapTests
    {
        const string API_KEY = "b9c77fa53374b9861bc3f87d684feb3a";

        [TestMethod]
        public async Task GetWeatherAsync()
        {
            var provider = new OpenWeatherMapProvider(API_KEY);

            string city = "appleton", state = "wi", country = "us";

            var weather = await provider.GetWeatherAsync(city, state, country);

            Assert.IsNotNull(weather);

        }
    }
}
