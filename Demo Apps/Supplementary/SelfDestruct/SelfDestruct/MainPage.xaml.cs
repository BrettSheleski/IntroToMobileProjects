using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SelfDestruct
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        CancellationTokenSource cancellationTokenSource;

        async void StartButton_Clicked(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();

            await StartCountdownAsync(cancellationTokenSource.Token);
        }

        async void Abort_Clicked(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();

            await DisplayAlert("Cancel", "Self destruct cancelled.", "Have a good day.");
        }

        async Task StartCountdownAsync(CancellationToken cancellationToken)
        {
            StartButton.IsEnabled = false;
            AbortButton.IsEnabled = true;

            for (int i = 10; i > 0; --i)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    StartButton.IsEnabled = true;
                    AbortButton.IsEnabled = false;
                    return;
                }

                CountdownLabel.Text = $"{i}";
                try
                {
                    await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
                }
                catch (TaskCanceledException)
                { // eat this exception 
                }
            }

            if (cancellationToken.IsCancellationRequested)
            {
                StartButton.IsEnabled = true;
                AbortButton.IsEnabled = false;
                return;
            }

            throw new Exception("Kaboom!");
        }
    }
}
