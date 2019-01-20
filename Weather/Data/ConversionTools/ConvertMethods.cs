using System;

namespace Weather.Data.ConversionTools
{
    public class ConvertMethods
    {
        public int KelvinToCelsius(double kelvin)
        {
            return (int)(kelvin - 273.15);
        }

        public TimeSpan UnixToTimeOfDay(int unix)
        {
            return DateTime.Parse(DateTimeOffset.FromUnixTimeSeconds(unix).ToString()).TimeOfDay;
        }
    }
}
