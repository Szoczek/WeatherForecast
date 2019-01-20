using System;
using System.Collections.Generic;

namespace Weather.Data.WeatherApiResponse.ForecastWeather
{
    class ForecastWeatherData
    {
        public int Dt { get; set; }
        public ForecastWeatherDataMain Main { get; set; }
        public IEnumerable<ForecastWeatherDataWeather> Weather { get; set; }
        public ForecastWeatherDataClouds Clouds { get; set; }
        public ForecastWeatherDataWind Wind { get; set; }
        public DateTime Dt_Txt { get; set; }
    }
}
