using System;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Weather.Data.ViewModel
{
    class CurrentWeatherDisplay
    {
        //Data
        public string LastUpdate { get; set; }
        public string LocationName { get; set; }
        //Data.Weather
        public string CurrentWeatherDescription { get; set; }
        public string CurrentWeatherIcon { get; set; }
        //Data.Main
        public string CurrentTemperature { get; set; }
        public string CurrentPressure { get; set; }
        public string CurrentHumidity { get; set; }
        //Data.Wind
        public string CurrentWindSpeed { get; set; }
        public string CurrentWindDirection { get; set; }
        //Data.Clouds
        public string CloudPercentage { get; set; }
        //Data.Sys
        public string CurrentSunrise { get; set; }
        public string CurrentSunset { get; set; }
        //Background & Icons
        public ImageBrush WindowBackground { get; set; }
        public BitmapImage WindowIcon { get; set; }
        public int Angle { get; set; }
        //Weather Data
        public WeatherApiResponse.CurrentWeather.CurrentWeatherBase CurrentWeatherInfo { get; set; }
        //Tools
        public ConversionTools.ConvertMethods Tools { get; set; } = new ConversionTools.ConvertMethods();

        public CurrentWeatherDisplay(WeatherApiResponse.CurrentWeather.CurrentWeatherBase CurrentWeatherResponse )
        {
            CurrentWeatherInfo = CurrentWeatherResponse;
            Dispatcher.CurrentDispatcher.InvokeAsync(() => CurrentDisplay());
        }

        private void CurrentDisplay()
        {
            //Data
            LastUpdate = "Last update: " + Tools.UnixToTimeOfDay(CurrentWeatherInfo.Response.Data.Dt).ToString();
            LocationName = CurrentWeatherInfo.Response.Data.Name + "," + CurrentWeatherInfo.Response.Data.Sys.Country.ToString();
            //Data.Weather
            CurrentWeatherDescription = CurrentWeatherInfo.Response.Data.Weather.First().Description.ToString();
            CurrentWeatherIcon = string.Format("http://openweathermap.org/img/w/{0}.png", CurrentWeatherInfo.Response.Data.Weather.First().Icon);
            //Data.Main
            CurrentTemperature = Tools.KelvinToCelsius(CurrentWeatherInfo.Response.Data.Main.Temp).ToString() + "°C";
            CurrentPressure = "Pressure: " + CurrentWeatherInfo.Response.Data.Main.Pressure.ToString() + "hPa";
            CurrentHumidity = "Humidity: " + CurrentWeatherInfo.Response.Data.Main.Humidity.ToString() + "%";
            //Data.Wind
            CurrentWindSpeed = CurrentWeatherInfo.Response.Data.Wind.Speed.ToString() + "m/s";
            CurrentWindDirection = CurrentWeatherInfo.Response.Data.Wind.Deg.ToString() + "°";
            //Data.Clouds
            CloudPercentage = "Cloudiness: " + CurrentWeatherInfo.Response.Data.Clouds.All.ToString() + "%";
            //Data.Sys
            CurrentSunrise = "Sunrise: " + Tools.UnixToTimeOfDay(CurrentWeatherInfo.Response.Data.Sys.Sunrise).ToString();
            CurrentSunset = "Sunset: " + Tools.UnixToTimeOfDay(CurrentWeatherInfo.Response.Data.Sys.Sunset).ToString();
            //Background & Icons
            WindowBackground = new ImageBrush(new BitmapImage(SetBackground()));
            WindowIcon = new BitmapImage(new Uri(CurrentWeatherIcon, UriKind.Absolute));
            Angle = CurrentWeatherInfo.Response.Data.Wind.Deg;
        }

        private Uri SetBackground()
        {
            return
                CurrentWeatherInfo.Response.Data.Weather.First().Id < 300 ? new Uri("Data/Images/Backgrounds/Thunderstorm.jpg", UriKind.Relative) :
                CurrentWeatherInfo.Response.Data.Weather.First().Id < 600 ? new Uri("Data/Images/Backgrounds/Raining.jpg", UriKind.Relative) :
                CurrentWeatherInfo.Response.Data.Weather.First().Id < 700 ? new Uri("Data/Images/Backgrounds/Snowing.jpg", UriKind.Relative) :
                CurrentWeatherInfo.Response.Data.Weather.First().Id < 800 ? new Uri("Data/Images/Backgrounds/Mist.jpg", UriKind.Relative) :
                CurrentWeatherInfo.Response.Data.Weather.First().Id < 802 ? new Uri("Data/Images/Backgrounds/Sunny.jpg", UriKind.Relative) :
                new Uri("Data/Images/Backgrounds/Clouds.jpg", UriKind.Relative);
        }
    }
}
