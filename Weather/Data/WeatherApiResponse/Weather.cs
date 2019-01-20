using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Data.WeatherApiResponse
{
    public abstract class Weather<T>
    {
        public virtual double Latitude { get; set; }
        public virtual double Longitude { get; set; }
        public virtual RestClient Client { get; set; }
        public virtual RestRequest Request { get; set; }
        public virtual IRestResponse<T> Response { get; set; }

        public Weather(double lat, double lon)
        {
            Latitude = lat;
            Longitude = lon;
        }

        public virtual void InitClient()
        {
            Client = new RestClient("https://api.openweathermap.org");
        }
        public abstract void InitRequest();
        public abstract void InitResponse();
    }
}
