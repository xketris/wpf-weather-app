using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using System.Diagnostics;

namespace WeatherApp.Converters
{
    public class TemperatureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                string temperature = (string)value;
                double temperatureDouble = System.Convert.ToDouble(temperature.Substring(0, temperature.Length - 2));
                if (temperatureDouble <= 8) return "/Assets/low-temp.png";
                if (temperatureDouble > 24) return "/Assets/high-temp.png";
            }
            
            return "/Assets/mid-temp.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case "/Assets/low-temp.png":
                    return 8;
                case "/Assets/mid-temp.png":
                    return 24;
                case "/Assets/high-temp.png":
                    return 32;
            }
            return 24;
        }
    }
}
