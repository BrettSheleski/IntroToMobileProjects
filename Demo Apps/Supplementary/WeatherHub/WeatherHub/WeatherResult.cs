namespace WeatherHub
{
    public class WeatherResult
    {
        public WeatherResult(ITemperature temperature, LatitudeLongitude location)
        {
            this.Temperature = temperature.ToKelvin().ToCelsius();
            this.Location = location;
        }

        public DegreesCelsius Temperature { get; }
        public LatitudeLongitude Location { get; }
    }
}