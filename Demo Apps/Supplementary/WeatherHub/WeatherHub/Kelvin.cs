namespace WeatherHub
{
    public struct Kelvin : ITemperature
    {
        public Kelvin(double amount)
        {
            this.Amount = amount;
        }

        public double Amount { get; }

        public int CompareTo(ITemperature other)
        {
            return Amount.CompareTo(other.ToKelvin().Amount);
        }

        public Kelvin ToKelvin()
        {
            return this;
        }

        public static Kelvin Zero { get; } = new Kelvin(0);

        const double KelvinToCelsius = -273.15;

        public DegreesCelsius ToCelsius()
        {
            return new DegreesCelsius(this.Amount + KelvinToCelsius);
        }

        public static implicit operator Kelvin(DegreesFahrenheit f) => f.ToCelsius().ToKelvin();
        public static implicit operator Kelvin(DegreesCelsius c) => c.ToKelvin();
    }
}
