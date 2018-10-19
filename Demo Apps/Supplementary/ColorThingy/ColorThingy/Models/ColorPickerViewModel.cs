using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ColorThingy.Models
{
    public class ColorPickerViewModel : ViewModelBase
    {
        public ColorPickerViewModel()
        {
            InvertColorCommand = new Command(InvertColor);
        }

        public ICommand InvertColorCommand { get; }

        private ushort _red, _green, _blue;

        public Color Color
        {
            get
            {
                return Color.FromRgb(Red, Green, Blue);
            }
        }

        public ushort Red
        {
            get { return _red; }
            set
            {
                _red = value;
                OnPropertyChanged();
                OnPropertyChanged("Color");
            }
        }
        public ushort Green
        {
            get { return _green; }
            set
            {
                _green = value;
                OnPropertyChanged();
                OnPropertyChanged("Color");
            }
        }
        public ushort Blue
        {
            get { return _blue; }
            set
            {
                _blue = value;
                OnPropertyChanged();
                OnPropertyChanged("Color");
            }
        }

        private void InvertColor()
        {
            ushort r, g, b;

            r = Green;
            g = Blue;
            b = Red;

            Red = r;
            Green = g;
            Blue = b;
        }


    }

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
