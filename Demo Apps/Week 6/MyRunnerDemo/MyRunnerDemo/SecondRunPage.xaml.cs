using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyRunnerDemo
{
    public partial class SecondRunPage : ContentPage
    {
        public SecondRunPage()
        {
            InitializeComponent();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();


            double minutes, seconds, miles;

            double.TryParse(MinutesEntry.Text, out minutes);
            double.TryParse(SecondsEntry.Text, out seconds);
            double.TryParse(MilesEntry.Text, out miles);


            TimeSpan runTime = TimeSpan.FromMinutes(minutes).Add(TimeSpan.FromSeconds(seconds));


            App.RunCalcator.Run2Time = runTime;
            App.RunCalcator.Run2Distance = miles;

        }
    }
}
