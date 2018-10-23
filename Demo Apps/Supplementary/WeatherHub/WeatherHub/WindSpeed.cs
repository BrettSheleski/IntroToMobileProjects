using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherHub
{
    public struct WindSpeed
    {
        public WindSpeed(ISpeed speed, double direction)
        {
            this.Speed = speed;
            this.Direction = direction % 360;
        }

        public ISpeed Speed { get; }

        public double Direction { get; }
    }
}
