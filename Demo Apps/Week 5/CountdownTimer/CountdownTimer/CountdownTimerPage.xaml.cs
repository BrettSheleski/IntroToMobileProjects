using Xamarin.Forms;
using System;

namespace CountdownTimer
{
    public partial class CountdownTimerPage : ContentPage
    {
        public CountdownTimerPage()
        {
            InitializeComponent();
        }

        TimeSpan updateInterval = TimeSpan.FromMilliseconds(100);

        DateTime deathTime;

        bool UpdateTimeLeftToLive()
        {

            TimeSpan timeLeftToLive = deathTime - DateTime.Now;

            double secondsUntilDeath = timeLeftToLive.TotalSeconds;

            RemainingTimeToLiveLabel.Text = secondsUntilDeath.ToString();

            bool amIAlive;

            if (DateTime.Now > deathTime)
            {
                amIAlive = false;

                Device.BeginInvokeOnMainThread(DisplayYouAreDeadMessage);

                this.UpdateChildrenLayout();
            }
            else
            {
                amIAlive = true;
            }

            return amIAlive;
        }

        void DisplayYouAreDeadMessage(){

            YoureDeadLabel.IsVisible = true;
            RemainingTimeToLiveLabel.Text = "0";

        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            double secondsToLive;

            if (double.TryParse(SecondsToLiveEntry.Text, out secondsToLive))
            {

                deathTime = DateTime.Now.AddSeconds(secondsToLive);

                Device.StartTimer(updateInterval, UpdateTimeLeftToLive);

            }
        }
    }
}
