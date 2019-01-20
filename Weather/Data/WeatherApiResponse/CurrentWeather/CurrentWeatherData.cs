using System.Collections.Generic;

namespace Weather.Data.WeatherApiResponse.CurrentWeather
{
    class CurrentWeatherData
    {
        public IEnumerable<CurrentWeatherDataWeather> Weather { get; private set; }
        public CurrentWeatherDataMain Main { get; private set; }
        public CurrentWeatherDataWind Wind { get; private set; }
        public CurrentWeatherDataClouds Clouds { get; private set; }
        public int Dt { get; private set; }
        public CurrentWeatherDataSys Sys { get; private set; }
        public string Name { get; private set; }
    }
}
