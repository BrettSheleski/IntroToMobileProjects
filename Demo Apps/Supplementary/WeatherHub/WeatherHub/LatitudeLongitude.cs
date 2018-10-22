using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherHub
{
    public struct LatitudeLongitude
    {
        public LatitudeLongitude(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public double Latitude { get; }
        public double Longitude { get; }
    }
}
