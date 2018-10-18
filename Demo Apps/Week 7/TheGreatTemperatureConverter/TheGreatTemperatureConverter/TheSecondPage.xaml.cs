using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TheGreatTemperatureConverter
{
    public partial class TheSecondPage : ContentPage
    {
        public TheSecondPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
