using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherHub.AccuWeather
{
    public class CurrentConditionsResult
    {
        public DateTime LocalObservationDateTime { get; set; }
        public int EpochTime { get; set; }
        public string WeatherText { get; set; }
        public int WeatherIcon { get; set; }
        public bool IsDayTime { get; set; }
        public Temperature Temperature { get; set; }
        public RealFeelTemperature RealFeelTemperature { get; set; }
        public RealFeelTemperatureShade RealFeelTemperatureShade { get; set; }
        public int RelativeHumidity { get; set; }
        public DewPoint DewPoint { get; set; }
        public Wind Wind { get; set; }
        public WindGust WindGust { get; set; }
        public int UVIndex { get; set; }
        public string UVIndexText { get; set; }
        public Visibility Visibility { get; set; }
        public string ObstructionsToVisibility { get; set; }
        public int CloudCover { get; set; }

        internal WeatherResult ToWeatherResult(LocationResult location)
        {
            ITemperature temperature = new DegreesFahrenheit(this.Temperature.Value);
            WindSpeed windSpeed = new WindSpeed(new MilesPerHour(this.Wind.Speed.Imperial.Value), this.Wind.Direction.Degrees);
            LatitudeLongitude latLong = new LatitudeLongitude(location.GeoPosition.Latitude, location.GeoPosition.Longitude);

            return new WeatherResult(temperature, latLong, windSpeed);
        }

        public Ceiling Ceiling { get; set; }
        public Pressure Pressure { get; set; }
        public PressureTendency PressureTendency { get; set; }
        public Past24HourTemperatureDeparture Past24HourTemperatureDeparture { get; set; }
        public ApparentTemperature ApparentTemperature { get; set; }
        public WindChillTemperature WindChillTemperature { get; set; }
        public WetBulbTemperature WetBulbTemperature { get; set; }
        public Precip1hr Precip1hr { get; set; }
        public PrecipitationSummary PrecipitationSummary { get; set; }
        public TemperatureSummary TemperatureSummary { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }


    public class RealFeelTemperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    

    public class RealFeelTemperatureShade
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

  

    public class DewPoint
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class Direction
    {
        public int Degrees { get; set; }
        public string Localized { get; set; }
        public string English { get; set; }
    }


    public class Speed
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class Wind
    {
        public Direction Direction { get; set; }
        public Speed Speed { get; set; }
    }


    public class Speed2
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class WindGust
    {
        public Speed2 Speed { get; set; }
    }

    public class Visibility
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }


    public class Ceiling
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }


    public class Pressure
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class PressureTendency
    {
        public string LocalizedText { get; set; }
        public string Code { get; set; }
    }


    public class Past24HourTemperatureDeparture
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

  

    public class ApparentTemperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }



    public class WindChillTemperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }


    public class WetBulbTemperature
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }



    public class Precip1hr
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }



    public class Precipitation
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }


    public class PastHour
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }
    

    public class Past3Hours
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }



    public class Past6Hours
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }



    public class Past9Hours
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }



    public class Past12Hours
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }


    public class Past18Hours
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }


    public class Past24Hours
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class PrecipitationSummary
    {
        public Precipitation Precipitation { get; set; }
        public PastHour PastHour { get; set; }
        public Past3Hours Past3Hours { get; set; }
        public Past6Hours Past6Hours { get; set; }
        public Past9Hours Past9Hours { get; set; }
        public Past12Hours Past12Hours { get; set; }
        public Past18Hours Past18Hours { get; set; }
        public Past24Hours Past24Hours { get; set; }
    }


    public class Minimum
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }


    public class Maximum
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class Past6HourRange
    {
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }
    
    public class Minimum2
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }
    
    public class Maximum2
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class Past12HourRange
    {
        public Minimum2 Minimum { get; set; }
        public Maximum2 Maximum { get; set; }
    }

    public class Minimum3
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }


    public class Maximum3
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }

    public class Past24HourRange
    {
        public Minimum3 Minimum { get; set; }
        public Maximum3 Maximum { get; set; }
    }

    public class TemperatureSummary
    {
        public Past6HourRange Past6HourRange { get; set; }
        public Past12HourRange Past12HourRange { get; set; }
        public Past24HourRange Past24HourRange { get; set; }
    }
}