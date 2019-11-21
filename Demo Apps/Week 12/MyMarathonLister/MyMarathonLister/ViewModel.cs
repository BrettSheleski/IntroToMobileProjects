using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyMarathonLister
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);

                PropertyChanged(this, e);
            }
        }
    }
}
