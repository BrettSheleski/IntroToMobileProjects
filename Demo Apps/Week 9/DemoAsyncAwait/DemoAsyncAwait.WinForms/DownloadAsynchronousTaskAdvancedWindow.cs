using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoAsyncAwait.WinForms
{
    public partial class DownloadAsynchronousTaskAdvancedWindow : Form
    {
        public DownloadAsynchronousTaskAdvancedWindow()
        {
            InitializeComponent();
        }

        CancellationTokenSource cancellationTokenSource;

        TimeSpan totalOperationTime;

        private async void StartDownloadButton_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "Download Started";

            Random r = new Random();

            int numberOfSeconds = r.Next(5, 20);

            totalOperationTime = TimeSpan.FromSeconds(numberOfSeconds);

            Progress<TimeSpan> progress = new Progress<TimeSpan>(UpdateProgressBar);

            this.cancellationTokenSource = new CancellationTokenSource();

            await FakeDownloadAsync(totalOperationTime, cancellationTokenSource.Token, progress);

            if (cancellationTokenSource.IsCancellationRequested)
            {
                MessageLabel.Text = "Download Canceled :(";
                ProgressBar.Value = 0;
            }
            else
            {
                MessageLabel.Text = "Download Completed";
            }
        }

        private void UpdateProgressBar(TimeSpan reportedTime)
        {
            double progressPercent = reportedTime.TotalMilliseconds / totalOperationTime.TotalMilliseconds;

            int progressInt = (int)(100 * progressPercent);

            this.ProgressBar.Value = progressInt;
        }

       





        private async Task FakeDownloadAsync(TimeSpan time, CancellationToken cancellationToken, IProgress<TimeSpan> progress)
        {
            double milliSeconds = time.TotalMilliseconds;

            int sleepMilliseconds = 100;

            for(int i = 0; i < milliSeconds; i += sleepMilliseconds)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    // the task has been requested to cancel, no need to continue
                    // do cleanup if needed
                    return;
                }
                else
                {
                    await Task.Delay(sleepMilliseconds);

                    progress.Report(TimeSpan.FromMilliseconds(i));
                }
            }

            progress.Report(time); // make sure to report when we're completed
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
        }

        private async void StartMultipleDownloadsButton_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "Download Started";

            cancellationTokenSource = new CancellationTokenSource();

            Random r = new Random();

            ProgressBar.Value = 0;
            
            for (int i = 0; i < 10; ++i)
            {
                int numberOfSeconds = r.Next(1, 5);

                if (!cancellationTokenSource.IsCancellationRequested)
                {
                    try
                    {
                        await Task.Delay(TimeSpan.FromSeconds(numberOfSeconds), cancellationTokenSource.Token);
                    }
                    catch (TaskCanceledException)
                    {
                        // Task.Delay() throws an exception if the cancellationToken was cancelled
                        // we'll just ignore it for this case
                    }
                    
                }

                ProgressBar.Value += 10;
            }

            if (cancellationTokenSource.IsCancellationRequested)
            {
                MessageLabel.Text = "Download Canceled :(";
                ProgressBar.Value = 0;
            }
            else
            {
                MessageLabel.Text = "Download Completed";
            }
        }
        
    }
}
