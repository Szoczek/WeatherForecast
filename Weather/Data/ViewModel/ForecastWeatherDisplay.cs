using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Weather.Data.WeatherApiResponse.ForecastWeather;
using Newtonsoft.Json;

namespace Weather.Data.ViewModel
{
    class ForecastWeatherDisplay
    {
        //every 3h forecast
        public Day[] DayForecast { get; set; } = new Day[10];
        //everyday forecast
        public Week[] WeekForecast { get; private set; } = new Week[7];
        //Weather Data
        public ForecastWeatherBase ForecastWeatherInfo { get; private set; }
        //Tools
        public ConversionTools.ConvertMethods Tools { get; private set; } = new ConversionTools.ConvertMethods();
        //JsonArray Deserializer
        public List<ForecastWeatherData> DeserializedWeatherData { get; private set; }

        public ForecastWeatherDisplay(ForecastWeatherBase ForecastWeatherResponse)
        {
            ForecastWeatherInfo = ForecastWeatherResponse;
            DeserializedWeatherData = DeseralizeWeatherData();
            InitDayForecast();
            Dispatcher.CurrentDispatcher.InvokeAsync(() => InitWeekForecast());
        }

        public List<ForecastWeatherData> DeseralizeWeatherData()
        {
             return JsonConvert.DeserializeObject<List<ForecastWeatherData>>(ForecastWeatherInfo.Response.Data.List.ToString());
        }

        public void InitDayForecast()
        {
            for (int i = 0; i < DayForecast.Length; i++)
            {
                DayForecast[i] = new Day
                {
                    TimeOfDay = DeserializedWeatherData[i].Dt_Txt.TimeOfDay.ToString(),
                    WeatherDescription = DeserializedWeatherData[i].Weather.First().Description.ToString(),
                    WeatherIcon = string.Format("http://openweathermap.org/img/w/{0}.png", DeserializedWeatherData[i].Weather.First().Icon),
                    Temperature = Tools.KelvinToCelsius(DeserializedWeatherData[i].Main.Temp_Max).ToString() + "°C / "
                    + Tools.KelvinToCelsius(DeserializedWeatherData[i].Main.Temp_Min).ToString() + "°C"
                };
            }
        }

        public void InitWeekForecast()
        {
            for (int i = 0; i < WeekForecast.Length; i++)
            {
            }
        }
    }
}
