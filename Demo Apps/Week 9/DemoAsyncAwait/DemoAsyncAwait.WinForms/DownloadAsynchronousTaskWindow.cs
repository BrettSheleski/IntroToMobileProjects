using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoAsyncAwait.WinForms
{
    public partial class DownloadAsynchronousTaskWindow : Form
    {
        public DownloadAsynchronousTaskWindow()
        {
            InitializeComponent();
        }

        const string DOWNLOAD_URL_100MB = "http://ipv4.download.thinkbroadband.com/100MB.zip";

        private async void StartDownloadButton_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "Downloading...";
            StartDownloadButton.Enabled = false;

            using (var webclient = new WebClient())
            {
                await webclient.DownloadDataTaskAsync(DOWNLOAD_URL_100MB);
            }


            MessageLabel.Text = "Done Downloading";
            StartDownloadButton.Enabled = true;
        }

        const int NUMBER_TO_DOWNLOAD = 3;

        private async void StartMultipleDownloadsButton_Click(object sender, EventArgs e)
        {
            StartMultipleDownloadsButton.Enabled = false;


            for(int i = 0; i < NUMBER_TO_DOWNLOAD; ++i)
            {
                MessageLabel.Text = $"Downloading file #{i + 1}";
                using (var webclient = new WebClient())
                {
                    await webclient.DownloadDataTaskAsync(DOWNLOAD_URL_100MB);
                }
            }

            MessageLabel.Text = "Done Downloading";
            StartMultipleDownloadsButton.Enabled = true;
        }

        private async void DownloadMultipleInParallelButton_Click(object sender, EventArgs e)
        {

            StartMultipleDownloadsButton.Enabled = false;
            MessageLabel.Text = "Starting Download...";

            List<Task> downloadTasks = new List<Task>();


            for (int i = 0; i < NUMBER_TO_DOWNLOAD; ++i)
            {
                downloadTasks.Add(DownloadAsync());
            }

            await Task.WhenAll(downloadTasks);

            MessageLabel.Text = "Done Downloading";
            StartMultipleDownloadsButton.Enabled = true;

        }

        async Task DownloadAsync()
        {
            using (var webclient = new WebClient())
            {
                await webclient.DownloadDataTaskAsync(DOWNLOAD_URL_100MB);
            }
        }
    }
}
