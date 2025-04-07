using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace WeatherApp.Converters
{
    public class WeatherConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                return GetImageSourceFromEn(value);
            }
            
            return "/Assets/few-clouds.png";
        }

        private object GetImageSourceFromEn(object value)
        {
            switch (((string)value).ToLower())
            {
                case "clear sky":
                    return "/Assets/sun.png";
                case "few clouds":
                    return "/Assets/few-clouds.png";
                case "scattered clouds":
                    return "/Assets/clouds.png";
                case "overcast clouds":
                case "broken clouds":
                    return "/Assets/broken-clouds.png";
                case "light intensity drizzle":
                case "drizzle":
                case "heavy intensity drizzle":
                case "light intensity drizzle rain":
                case "drizzle rain":
                case "heavy intensity drizzle rain":
                case "shower rain and drizzle":
                case "heavy shower rain and drizzle":
                case "shower drizzle":
                    return "/Assets/shower-rain.png";
                case "light rain":
                case "moderate rain":
                case "heavy intensity rain":
                case "very heavy rain":
                case "shower rain":
                case "heavy intensity shower rain":
                case "ragged shower rain":
                case "extreme rain":
                    return "/Assets/rain.png";
                case "thunderstorm with light rain":
                case "thunderstorm with rain":
                case "thunderstorm with heavy rain":
                case "light thunderstorm":
                case "thunderstorm":
                case "heavy thunderstorm":
                case "ragged thunderstorm":
                case "thunderstorm with light drizzle":
                case "thunderstorm with drizzle":
                case "thunderstorm with heavy drizzle":
                    return "/Assets/thunderstorm.png";
                case "freezing rain":
                case "light snow":
                case "snow":
                case "heavy snow":
                case "sleet":
                case "light shower sleet":
                case "shower sleet":
                case "light rain and snow":
                case "rain and snow":
                case "light shower snow":
                case "shower snow":
                case "heavy shower snow":
                    return "/Assets/snow.png";
                case "mist":
                case "smoke":
                case "haze":
                case "sand/dust whirls":
                case "fog":
                case "sand":
                case "dust":
                case "volcanic ash":
                case "squalls":
                case "tornado":
                    return "/Assets/mist.png";
            }
            return "/Assets/few-clouds.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value)
            {
                case "/Assets/sun.png":
                    return "clear sky";
                case "/Assets/few-clouds.png":
                    return "few clouds";
                case "/Assets/clouds.png":
                    return "scattered clouds";
                case "/Assets/broken-clouds.png":
                    return "broken clouds";
                case "/Assets/shower-rain.png":
                    return "shower rain";
                case "/Assets/rain.png":
                    return "rain";
                case "/Assets/thunderstorm.png":
                    return "thunderstorm";
                case "/Assets/snow.png":
                    return "snow";
                case "/Assets/mist.png":
                    return "mist";
            }
            return "few clouds";
        }
    }
}
