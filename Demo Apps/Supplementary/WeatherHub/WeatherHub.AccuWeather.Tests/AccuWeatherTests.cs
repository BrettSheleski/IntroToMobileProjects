using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WeatherHub.AccuWeather.Tests
{
    [TestClass]
    public class AccuWeatherTests
    {
        const string API_KEY = "Q57v6aEByMGhz3JBGmSGNAlLDpsVN3n6";

        [TestMethod]
        public async Task GetWeatherForAppleton()
        {
            AccuWeather.AccuWeatherWeatherProvider provider = new AccuWeatherWeatherProvider(API_KEY);

            var result = await provider.GetWeatherAsync("appleton, WI", "us");


            Assert.IsNotNull(result);
        }
    }
}
