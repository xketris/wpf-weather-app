using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WeatherApp.Models;

namespace WeatherApp
{
    public partial class MainWindow : Window
    {
        private WeatherService _ws;

        private FilterView FilterViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _ws = new WeatherService();
            FilterViewModel = new FilterView();
            this.DataContext = FilterViewModel;
        }
        private void Cmb_KeyUp(object sender, KeyEventArgs e)
        {
            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(City.ItemsSource);

            itemsViewOriginal.Filter = ((o) =>
            {
                if (String.IsNullOrEmpty(City.Text)) return true;
                else
                {
                    if (((string)o).Contains(City.Text)) return true;
                    else return false;
                }
            });

            itemsViewOriginal.Refresh();
        }

        private string Capitalize(string str)
        {
            if (str.Length == 0)
            {
                return "";
            }
            return str.Length == 1 ? Convert.ToString(char.ToUpper(str[0])) : (char.ToUpper(str[0]) + str.Substring(1));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            WeatherData? weatherData = await _ws.GetWeatherAsync(City.Text);

            if (weatherData != null)
            {

                FilterViewModel.Temperature = $"{weatherData?.Main?.Temperature}°C";
                Humidity.Text = $"{weatherData?.Main?.Humidity}%";
                FilterViewModel.Description = $"{Capitalize(weatherData?.Weather?[0].Description)}";
                FilterViewModel.IsValid = true;
            }
            else
            {
                FilterViewModel.IsValid = false;
            }
        }
    }
}