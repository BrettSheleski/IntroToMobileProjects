using System;
using System.Globalization;
using Xamarin.Forms;

namespace FamilyList
{
    public class DatetimeToAgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date){
                return (int)(DateTime.Today.Subtract(date).TotalDays / 365);
            }
            else{
                return value;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
