namespace Weather.Data.ViewModel
{
    class WeatherDisplay
    {
        public WeatherApiResponse.CurrentWeather.CurrentWeatherBase CurrentWeatherInfo { get; set; } 
        public WeatherApiResponse.ForecastWeather.ForecastWeatherBase ForecastWeatherInfo { get; set; }
        public CurrentWeatherDisplay CurrentWeather { get; set; }
        public ForecastWeatherDisplay ForecastWeather { get; set; }

        public WeatherDisplay(double Lat, double Lon)
        {
            CurrentWeatherInfo = new WeatherApiResponse.CurrentWeather.CurrentWeatherBase(Lat, Lon);
            ForecastWeatherInfo = new WeatherApiResponse.ForecastWeather.ForecastWeatherBase(Lat, Lon);

            if (CurrentWeatherInfo.Response.IsSuccessful && ForecastWeatherInfo.Response.IsSuccessful)
            {
                CurrentWeather = new CurrentWeatherDisplay(CurrentWeatherInfo);
                ForecastWeather = new ForecastWeatherDisplay(ForecastWeatherInfo);
            }
        }
    }
}
