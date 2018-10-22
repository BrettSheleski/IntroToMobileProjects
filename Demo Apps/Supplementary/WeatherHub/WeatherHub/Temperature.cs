using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherHub
{
    public interface ITemperature : IComparable<ITemperature>
    {
        Kelvin ToKelvin();
        double Amount { get; }
    }
}
