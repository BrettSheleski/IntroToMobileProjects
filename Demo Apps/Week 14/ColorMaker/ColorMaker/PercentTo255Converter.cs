using System;
using System.Globalization;

namespace ColorMaker
{
    public class PercentTo255Converter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double d)
            {
                return (int)(d * 255);
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                double theDoubleValue;

                if (double.TryParse(str, out theDoubleValue))
                {
                    return theDoubleValue / 255.0;
                }
                else
                {
                    return value;
                }
            }
            else if (value is double d)
            {
                return d / 255.0;
            }
            else
            {
                return value;
            }
        }
    }
}
