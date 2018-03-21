using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoAsyncAwait.WinForms
{
    public partial class DownloadSynchronousWindow : Form
    {
        public DownloadSynchronousWindow()
        {
            InitializeComponent();
        }

        const string DOWNLOAD_URL_100MB = "http://ipv4.download.thinkbroadband.com/100MB.zip";
        const string DOWNLOAD_URL_1GB = "http://ipv4.download.thinkbroadband.com/1GB.zip";

        private void StartDownloadButton_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "Downloading, please wait";
            StartDownloadButton.Enabled = false;

            if (Program.SimulateDownloads)
            {
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(20));
            }
            else
            {
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                {
                    webClient.DownloadData(DOWNLOAD_URL_100MB);
                }
            }

            MessageLabel.Text = "Download Complete!";
            StartDownloadButton.Enabled = true;
        }

        const int NUMBER_OF_FILES_TO_DOWNLOAD = 3;

        private void StartMultipleDownloadsButton_Click(object sender, EventArgs e)
        {
            StartMultipleDownloadsButton.Enabled = false;


            for (int i = 0; i < NUMBER_OF_FILES_TO_DOWNLOAD; ++i)
            {
                MessageLabel.Text = $"Downloading file #{i + 1}";

                if (Program.SimulateDownloads)
                {
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(20));
                }
                else
                {
                    using (System.Net.WebClient webClient = new System.Net.WebClient())
                    {
                        webClient.DownloadData(DOWNLOAD_URL_100MB);
                    }
                }
            }


            MessageLabel.Text = "Downloads Complete!";
            StartMultipleDownloadsButton.Enabled = true;
        }
    }
}
