using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace WeatherApp
{
    public partial class MainWindow : Window
    {
        private WeatherService _ws;

        public MainWindow()
        {
            InitializeComponent();
            _ws = new WeatherService();
            FilterViewModel vm = new FilterViewModel();
            this.DataContext = vm;
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            WeatherData? weatherData = await _ws.GetWeatherAsync(City.Text);

            if (weatherData != null)
            {
                string weatherInfo = $"Temperatura: {weatherData?.Main?.Temperature}°C\n";
                weatherInfo += $"Wilgotność: {weatherData?.Main?.Humidity}%\n";
                weatherInfo += $"Opis: {weatherData?.Weather?[0].Description}";

                Display.Text = weatherInfo;
            }
            else
            {
                Display.Text = "Błąd pobierania danych pogodowych.";
            }
        }
    }

    public class FilterViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> dataSource;
        public ObservableCollection<string> DataSource
        {
            get
            {
                return dataSource;
            }
            set { dataSource = value; OnPropertyChanged("ListOfCountry"); }
        }
        public FilterViewModel()
        {
            dataSource = new ObservableCollection<string>();
            dataSource.Add("Tokio");
            dataSource.Add("Vienna");
            dataSource.Add("Prague");
            dataSource.Add("Berlin");
            dataSource.Add("London");
            dataSource.Add("Warsaw");
            dataSource.Add("Paris");
            dataSource.Add("Rome");
            dataSource.Add("Oslo");
            dataSource.Add("Madrid");
            dataSource.Add("Lisbon");
            dataSource.Add("Helsinki");
            dataSource.Add("Athens");
            dataSource.Add("Amsterdam");
            dataSource.Add("Bangkok");
            dataSource.Add("Ottawa");
            dataSource.Add("Budapest");
            dataSource.Add("Seoul");
            dataSource.Add("Moscow");
            dataSource.Add("Kyvi");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        internal void OnPropertyChanged([CallerMemberName] string propName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}