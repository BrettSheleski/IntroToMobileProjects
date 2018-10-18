using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TheGreatTemperatureConverter
{
    public partial class TheFirstPage : ContentPage
    {
        public TheFirstPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new TheSecondPage());
        }
    }
}
