using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherHub
{
    public interface ISpeed
    {
        double Amount { get; }

        KilometersPerHour ToKilometersPerHour();
    }

    public struct MilesPerHour : ISpeed
    {
        public MilesPerHour(double amount)
        {
            this.Amount = amount;
        }

        public double Amount { get; }

        const double KmPerMile = 1.609;
        const double MphPerFps = 1.46667;

        public KilometersPerHour ToKilometersPerHour()
        {
            return new KilometersPerHour(Amount * KmPerMile);
        }



        public FeetPerSecond ToFeetPerSecond()
        {
            return new FeetPerSecond(Amount * MphPerFps);
        }
    }

    public struct FeetPerSecond : ISpeed
    {
        public FeetPerSecond(double amount)
        {
            this.Amount = amount;
        }

        public double Amount { get; }

        public KilometersPerHour ToKilometersPerHour()
        {
            return new KilometersPerHour(Amount * FpsToKph);
        }

        const double FpsToKph = 1.09728;
        const double FpsToMph = 0.68181973159091;

        public MilesPerHour ToMilesPerHour()
        {
            return new MilesPerHour(Amount * FpsToMph);
        }
    }

    public struct MetersPerSecond : ISpeed
    {
        public MetersPerSecond(double amount)
        {
            this.Amount = amount;
        }

        public double Amount { get; }


        const double MpsToKph = 3.6;

        public KilometersPerHour ToKilometersPerHour()
        {
            return new KilometersPerHour(Amount * MpsToKph);
        }
    }

    public struct KilometersPerHour : ISpeed
    {
        public KilometersPerHour(double amount)
        {
            this.Amount = amount;
        }

        public double Amount { get; }

        public KilometersPerHour ToKilometersPerHour()
        {
            return this;
        }
        const double KphToMph = 0.621371;

        public MilesPerHour ToMilesPerHour()
        {
            return new MilesPerHour(Amount * KphToMph);
        }
    }
}
