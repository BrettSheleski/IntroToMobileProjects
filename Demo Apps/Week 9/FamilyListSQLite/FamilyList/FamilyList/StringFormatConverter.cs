using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace FamilyList
{
    public class StringFormatConverter : IValueConverter
    {
        public string Format { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrWhiteSpace(Format))
            {
                // we cannot convert the given value, return it as-is
                return value;
            }
            else
            {
                return string.Format(Format, value);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // we cannot convert back, return the given value to indicate this.
            return value;
        }
    }
}
