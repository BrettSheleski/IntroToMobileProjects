using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace WeatherHub.Xamarin.Converters
{
    public class DegreesToCardinalDirectionConverter : IValueConverter
    {

        const double SIZE = 22.5;

        const double N_MIN = -12.25;
        const double N_MAX = 12.25;
        const double NNE_MIN = N_MAX;
        const double NNE_MAX = NNE_MIN + SIZE;
        const double NE_MIN = NNE_MAX;
        const double NE_MAX = NE_MIN + SIZE;
        const double ENE_MIN = NE_MAX;
        const double ENE_MAX = ENE_MIN + SIZE;

        const double E_MIN = ENE_MAX;
        const double E_MAX = E_MIN + SIZE;

        const double ESE_MIN = E_MAX;
        const double ESE_MAX = ESE_MIN + SIZE;

        const double SE_MIN = ESE_MAX;
        const double SE_MAX = SE_MIN + SIZE;

        const double SSE_MIN = SE_MAX;
        const double SSE_MAX = SSE_MIN + SIZE;

        const double S_MIN = SSE_MAX;
        const double S_MAX = S_MIN + SIZE;

        const double SSW_MIN = S_MAX;
        const double SSW_MAX = SSW_MIN + SIZE;

        const double SW_MIN = SSW_MAX;
        const double SW_MAX = SW_MIN + SIZE;

        const double WSW_MIN = SW_MAX;
        const double WSW_MAX = WSW_MIN + SIZE;

        const double W_MIN = WSW_MAX;
        const double W_MAX = W_MIN + SIZE;

        const double WNW_MIN = W_MAX;
        const double WNW_MAX = WNW_MIN + SIZE;

        const double NW_MIN = WNW_MAX;
        const double NW_MAX = NW_MIN + SIZE;

        const double NNW_MIN = NW_MAX;
        const double NNW_MAX = NNW_MIN + SIZE;


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double degrees)
            {
                if (degrees < NNE_MIN || degrees > NNW_MAX)
                    return "N";
                else if (degrees < NE_MIN)
                    return "NNE";
                else if (degrees < ENE_MIN)
                    return "NE";
                else if (degrees < E_MIN)
                    return "ENE";
                else if (degrees < ENE_MIN)
                    return "E";
                else if (degrees < SE_MIN)
                    return "ESE";
                else if (degrees < SSE_MIN)
                    return "SE";
                else if (degrees < S_MIN)
                    return "SSE";
                else if (degrees < SSW_MIN)
                    return "S";
                else if (degrees < SW_MIN)
                    return "SSW";
                else if (degrees < WSW_MIN)
                    return "SW";
                else if (degrees < W_MIN)
                    return "WSW";
                else if (degrees < WNW_MIN)
                    return "W";
                else if (degrees < NW_MIN)
                    return "WNW";
                else if (degrees < NNW_MIN)
                    return "NW";
                else
                    return "NNW";
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
    }
}
