namespace WeatherHub
{
    public struct DegreesCelsius : ITemperature
    {
        public DegreesCelsius(double amount)
        {
            this.Amount = amount;
        }

        public double Amount { get; }
        public int CompareTo(ITemperature other)
        {
            return this.ToKelvin().CompareTo(other);
        }

        public Kelvin ToKelvin()
        {
            return new Kelvin(Amount + CelsiusToKelvin);
        }

        const double NineFifths = 9 / 5d;

        const double CelsiusToKelvin = 273.15;

        public DegreesFahrenheit ToFahrenheit()
        {
            return new DegreesFahrenheit((Amount * NineFifths) + 32);
        }

        public static implicit operator DegreesCelsius(DegreesFahrenheit f) => f.ToCelsius();
        public static implicit operator DegreesCelsius(Kelvin k) => k.ToCelsius();
    }
}
