using SimpleJson;

namespace Weather.Data.WeatherApiResponse.ForecastWeather
{
    class ForecastWeatherJsonArray
    {
        public int Cnt { get; set; }
        public JsonArray List { get; set; }
    }
}
