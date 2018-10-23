namespace WeatherHub
{
    public class WeatherResult
    {
        public WeatherResult(ITemperature temperature, LatitudeLongitude location, WindSpeed windSpeed)
        {
            this.Temperature = temperature.ToKelvin().ToCelsius();
            this.Location = location;
            this.WindSpeed = windSpeed;
        }

        public DegreesCelsius Temperature { get; }
        public LatitudeLongitude Location { get; }

        public WindSpeed WindSpeed { get; }
    }
}