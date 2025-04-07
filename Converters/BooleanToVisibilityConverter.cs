using System;
using System.Windows.Data;
using System.Windows;

namespace WeatherApp.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                return (bool)value == false ? Visibility.Hidden : Visibility.Visible;
            }
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch(value)
            {
                case Visibility.Visible:
                    return true;
                case Visibility.Hidden:
                    return false;
            }
            return false;
        }
    }
}
