using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ColorThingy.Converters
{
    public class ColorToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Color color)
            {
                // this sucks :(
                // also has a performance problem... ;(
                //return "Red: " + NumberToHex(color.R) + ", Blue: " + NumberToHex(color.G) + ", Green:" + NumberToHex(color.B);

                // this sucks less...
                // but performs better
                //return string.Format("Red: {0}, Blue: {1}, Green: {2}", color.R, color.B, color.G);

                

                string r = NumberToHex(color.R * 255);
                string g = NumberToHex(color.G * 255);
                string b = NumberToHex(color.B * 255);

                return $"{r}{g}{b}";
            }
            else
            {
                return value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue)
            {
                return Color.FromHex(stringValue);
            }
            else
            {
                return value;
            }
        }

        string NumberToHex(double number)
        {
            return IntToHex((int)number);
        }

        string IntToHex(int number)
        {
            string hex = ("00" + number.ToString("X"));

            hex = hex.Substring(hex.Length - 2);

            return hex;
        }
    }
}
