using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xml_app_libary;

namespace Xml_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Car> _cars = new ObservableCollection<Car>();
        public ObservableCollection<Car> Cars
        {
            get { return _cars; }
            set
            {
                _cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }
        private ObservableCollection<CarData> _data = new ObservableCollection<CarData>();
        public ObservableCollection<CarData> data
        {
            get { return _data; }
            set
            {
                _data = value;
                OnPropertyChanged(nameof(data));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            myDataGrid.ItemsSource = data;
        }
        private void Open_File(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Cars";
            dialog.DefaultExt = ".xml";
            dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            dialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                var loadedCars = Car.LoadCars(dialog.FileName);
                foreach (var car in loadedCars)
                {
                    Cars.Add(car);
                }
                var cardata = CarData.AllCarData(loadedCars);
                foreach (var dat in cardata)
                {
                    data.Add(dat);
                }
            }
        }
    }
}