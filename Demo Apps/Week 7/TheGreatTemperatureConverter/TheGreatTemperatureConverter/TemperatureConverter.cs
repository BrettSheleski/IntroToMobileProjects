using System;
namespace TheGreatTemperatureConverter
{
    public class TemperatureConverter
    {

        public string Title { get; set; }

        private double _input, _output;

        public double Input
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
                _output = ConverterDelegate(_input);
            }
        }

        public double Output { get { return _output; } }
            

        public Func<double, double> ConverterDelegate { get; set; }

    }
}
