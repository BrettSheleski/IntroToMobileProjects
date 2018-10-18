using System;
using System.ComponentModel;

namespace TheGreatTemperatureConverter
{
    public class TemperatureConverter : INotifyPropertyChanged
    {

        public string Title { get; set; }

        private double _input, _output;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName){

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public double Input
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
                OnPropertyChanged("Input");

                _output = ConverterDelegate(_input);
                OnPropertyChanged("Output");
            }
        }

        public double Output { get { return _output; } }
            

        public Func<double, double> ConverterDelegate { get; set; }

    }
}
