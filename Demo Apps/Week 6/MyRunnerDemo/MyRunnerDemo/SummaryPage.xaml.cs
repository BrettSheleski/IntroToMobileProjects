using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyRunnerDemo
{
    public partial class SummaryPage : ContentPage
    {
        public SummaryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            App.RunCalcator.Update();

            MilesLabel.Text = App.RunCalcator.TotalDistance.ToString();
            HoursLabel.Text = App.RunCalcator.TotalTime.Hours.ToString();
            MinutesLabel.Text = App.RunCalcator.TotalTime.Minutes.ToString();
            SecondsLabel.Text = App.RunCalcator.TotalTime.Seconds.ToString();

            SpeedLabel.Text = App.RunCalcator.AverageSpeed.ToString("0.##");
        }
    }
}
