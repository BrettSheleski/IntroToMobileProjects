namespace WeatherHub
{
    public struct DegreesFahrenheit : ITemperature
    {
        public double Amount { get; }

        public DegreesFahrenheit(double amount)
        {
            this.Amount = amount;
        }

        public int CompareTo(ITemperature other)
        {
            return this.ToKelvin().CompareTo(other);
        }

        public Kelvin ToKelvin()
        {
            return ToCelsius().ToKelvin();
        }

        const double FiveNinths = 5 / 9d;

        public DegreesCelsius ToCelsius()
        {
            return new DegreesCelsius((Amount - 32) * FiveNinths);
        }

        public static implicit operator DegreesFahrenheit(DegreesCelsius c) => c.ToFahrenheit();
        public static implicit operator DegreesFahrenheit(Kelvin k) => k.ToCelsius().ToFahrenheit();
    }
}
