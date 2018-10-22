using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherHub
{
    public interface IWeatherProvider
    {
        Task<WeatherResult> GetWeatherAsync(string city, string countryCode);
    }
}
