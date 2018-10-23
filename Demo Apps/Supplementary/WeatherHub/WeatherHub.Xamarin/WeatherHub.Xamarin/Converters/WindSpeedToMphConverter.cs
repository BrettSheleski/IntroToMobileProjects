using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace WeatherHub.Xamarin.Converters
{
    public class WindSpeedToMphConverter : IValueConverter
    {

        public string StringFormat { get; set; } = "{0:N0} Miles Per Hour";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ISpeed speed)
            {
                var mph = speed.ToKilometersPerHour().ToMilesPerHour();

                return string.Format(StringFormat, mph.Amount);
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
