using System;

namespace WeatherHub.AccuWeather
{
    public class TimeZone
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string GmtOffset { get; set; }
        public bool IsDaylightSaving { get; set; }
        public DateTime NextOffsetChange { get; set; }
    }
}
