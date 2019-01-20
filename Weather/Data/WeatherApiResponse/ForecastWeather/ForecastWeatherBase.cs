using RestSharp;

namespace Weather.Data.WeatherApiResponse.ForecastWeather
{
    class ForecastWeatherBase : Weather<ForecastWeatherJsonArray>
    {
        public ForecastWeatherBase(double lat, double lon) : base(lat, lon)
        {
            Latitude = lat;
            Longitude = lon;

            InitClient();
            InitRequest();
            InitResponse();
        }

        public override void InitRequest()
        {
            Request = new RestRequest("/data/2.5/forecast");
            Request.RequestFormat = DataFormat.Json;
            Request.AddParameter("appid", "2ac5c3fe1f60a83574dd144aa1dd2e4d");
            Request.AddParameter("lat", Latitude);
            Request.AddParameter("lon", Longitude);
        }

        public override void InitResponse()
        {
            Response = Client.Execute<ForecastWeatherJsonArray>(Request);
        }
    }
}
