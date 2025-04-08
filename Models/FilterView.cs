using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Models
{
    public class FilterView : INotifyPropertyChanged
    {
        private bool _isValid;

        public bool IsValid
        {
            get { return _isValid; }
            set
            {
                _isValid = value;
                OnPropertyChanged("IsValid");
            }
        }

        private string _temperature;

        public string Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                OnPropertyChanged("Temperature");
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private string _icon;

        public string Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                OnPropertyChanged("Icon");
            }
        }

        private ObservableCollection<string> dataSource;
        public ObservableCollection<string> DataSource
        {
            get
            {
                return dataSource;
            }
            set { dataSource = value; OnPropertyChanged("ListOfCountry"); }
        }
        public FilterView()
        {
            IsValid = true;
            Icon = "/Assets/WeatherType/01d.png";
            dataSource = new ObservableCollection<string>();
            dataSource.Add("Tokio");
            dataSource.Add("Wiedeń");
            dataSource.Add("Praga");
            dataSource.Add("Berlin");
            dataSource.Add("Londyn");
            dataSource.Add("Warszawa");
            dataSource.Add("Paryż");
            dataSource.Add("Rzym");
            dataSource.Add("Oslo");
            dataSource.Add("Madryt");
            dataSource.Add("Lisbona");
            dataSource.Add("Helsinki");
            dataSource.Add("Ateny");
            dataSource.Add("Amsterdam");
            dataSource.Add("Bangkok");
            dataSource.Add("Ottawa");
            dataSource.Add("Budapeszt");
            dataSource.Add("Seoul");
            dataSource.Add("Moskwa");
            dataSource.Add("Kijów");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        internal void OnPropertyChanged([CallerMemberName] string propName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
