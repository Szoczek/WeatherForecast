using System.Windows;

namespace Weather
{
    public partial class MainWindow : Window
    {
        private Data.ViewModel.WeatherDisplay ViewModel { get; set; }
        public MainWindow()
        {
            ViewModel = new Data.ViewModel.WeatherDisplay(49.877639, 18.921389);
            InitializeComponent();

            if (ViewModel.CurrentWeatherInfo.Response.IsSuccessful && ViewModel.ForecastWeatherInfo.Response.IsSuccessful)
            {
                DataContext = new
                {
                     ViewModel.CurrentWeather,
                     ViewModel.ForecastWeather.DayForecast,
                     ViewModel.ForecastWeather.WeekForecast
                };
            }
            else
            {
                this.Close();
                MessageBox.Show("Error!\nUnable to receive server response, please check your internet connection and try again.");
            }
        }
    }
}
