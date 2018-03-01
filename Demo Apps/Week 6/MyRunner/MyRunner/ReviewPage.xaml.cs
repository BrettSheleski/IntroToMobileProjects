using System;
using System.Collections.Generic;
using System.Threading;
using Xamarin.Forms;

namespace MyRunner
{
    public partial class ReviewPage : ContentPage
    {
        public ReviewPage()
        {
            InitializeComponent();
        }

        const double MILES_TO_THE_MOON = 238900;

        public void UpdateDisplayText(){
            App.RunCalculator.Update();

            MilesSpan.Text = App.RunCalculator.TotalDistance.ToString("0.##");
            HoursSpan.Text = App.RunCalculator.TotalTime.Hours.ToString();
            MinutesSpan.Text = App.RunCalculator.TotalTime.Minutes.ToString();
            SecondsSpan.Text = App.RunCalculator.TotalTime.Seconds.ToString();

            MilesPerHourSpan.Text = App.RunCalculator.AverageSpeed.ToString("0.##");



            if (App.RunCalculator.TotalTime > TimeSpan.Zero)
            {
                ToTheMoonLabel.IsVisible = true;


                FormattedString fs = new FormattedString();

                // D = R * T --> T = D / R

                double hoursToTheMoon = MILES_TO_THE_MOON / App.RunCalculator.TotalTime.TotalHours;

                // TimeSpans have an upper bound of time that they can represent
                // It will throw an exception when trying to represent more than that.
                // Avoid that exception by checking agains TimeSpan.MaxValue
                if (hoursToTheMoon > TimeSpan.MaxValue.TotalHours)
                {
                    ToMoonYearsSpan.Text = "a crap-ton of";
                    ToMoonDaysSpan.Text = "lots of";
                    ToMoonHoursSpan.Text = "some";
                    ToMoonMinutesSpan.Text = "more than 1";
                    ToMoonSecondsSpan.Text = "a few";
                }
                else
                {
                    TimeSpan timeToTheMoon = TimeSpan.FromHours(hoursToTheMoon);

                    int years = timeToTheMoon.Days / 365,  // note integer-division
                        days = timeToTheMoon.Days % 365;   // modulo-division

                    ToMoonYearsSpan.Text = years.ToString();
                    ToMoonDaysSpan.Text = days.ToString();
                    ToMoonHoursSpan.Text = timeToTheMoon.Hours.ToString();
                    ToMoonMinutesSpan.Text = timeToTheMoon.Minutes.ToString();
                    ToMoonSecondsSpan.Text = timeToTheMoon.Seconds.ToString();
                }

                foreach(Span span in ToTheMoonLabel.FormattedText.Spans){
                    fs.Spans.Add(span);
                }

                ToTheMoonLabel.FormattedText = fs;
            }
            else
            {
                ToTheMoonLabel.IsVisible = false;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            UpdateDisplayText();
        }
    }
}
