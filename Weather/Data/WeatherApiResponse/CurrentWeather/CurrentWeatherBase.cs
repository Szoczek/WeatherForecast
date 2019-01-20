using RestSharp;

namespace Weather.Data.WeatherApiResponse.CurrentWeather
{
    class CurrentWeatherBase : Weather<CurrentWeatherData>
    {
        public CurrentWeatherBase(double lat, double lon) : base(lat, lon)
        {
            Latitude = lat;
            Longitude = lon;

            InitClient();
            InitRequest();
            InitResponse();
        }

        public override void InitRequest()
        {
            Request = new RestRequest("/data/2.5/weather");
            Request.AddParameter("appid", "2ac5c3fe1f60a83574dd144aa1dd2e4d");
            Request.AddParameter("lat", Latitude);
            Request.AddParameter("lon", Longitude);
            Request.RequestFormat = DataFormat.Json;
        }

        public override void InitResponse()
        {
            Response = Client.Execute<CurrentWeatherData>(Request);
        }
    }
}
