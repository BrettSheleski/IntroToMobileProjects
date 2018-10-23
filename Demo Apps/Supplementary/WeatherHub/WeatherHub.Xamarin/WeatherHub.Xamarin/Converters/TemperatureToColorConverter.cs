using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace WeatherHub.Xamarin.Converters
{
    public class TemperatureToColorConverter : IValueConverter
    {
        public Color LowColor { get; set; } = Color.FromHex("A5F2F3");
        public Color HighColor { get; set; } = Color.FromHex("e25822");

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ITemperature temp)
            {
                var f = temp.ToKelvin().ToCelsius().ToFahrenheit();

                if (f.Amount <= 0)
                    return LowColor;
                else if (f.Amount >= 100)
                    return HighColor;

                Color color;

                double p = f.Amount / 100.0;
                double h, s, l;

                h = GetValueBetween(LowColor.Hue, HighColor.Hue, p);
                s = GetValueBetween(LowColor.Saturation, HighColor.Saturation, p);
                l = GetValueBetween(LowColor.Luminosity, HighColor.Luminosity, p);

                color = Color.FromHsla(h, s, l);

                return color;
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        double GetValueBetween(double low, double high, double percent)
        {
            if (low > high)
            {
                return high + ((low - high) * percent);
            }
            else
            {
                return low + ((high - low) * percent);
            }
        }
    }
}
