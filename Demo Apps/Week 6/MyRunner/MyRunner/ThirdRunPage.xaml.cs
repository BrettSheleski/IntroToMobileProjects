using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyRunner
{
    public partial class ThirdRunPage : ContentPage
    {
        public ThirdRunPage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            double miles, minutes, seconds;

            double.TryParse(MilesEntry.Text, out miles);
            double.TryParse(MinutesEntry.Text, out minutes);
            double.TryParse(SecondsEntry.Text, out seconds);

            TimeSpan time = TimeSpan.FromMinutes(minutes).Add(TimeSpan.FromSeconds(seconds));

            App.RunCalculator.Run3Time = time;
            App.RunCalculator.Run3Distance = miles;
        }
    }
}
