using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace WeatherHub.Xamarin.Converters
{
    public class TemperatureToDegreesFahrenheitConverter : IValueConverter
    {
        public string StringFormat { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ITemperature temperature)
            {
                DegreesFahrenheit f = temperature.ToKelvin().ToCelsius().ToFahrenheit();

                if (string.IsNullOrWhiteSpace(StringFormat))
                {
                    return f.Amount;
                }
                else
                {
                    return string.Format(StringFormat, f.Amount);
                }
                
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
