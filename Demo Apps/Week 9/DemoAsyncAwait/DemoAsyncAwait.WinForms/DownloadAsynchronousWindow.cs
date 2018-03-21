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
    public partial class DownloadAsynchronousWindow : Form
    {
        public DownloadAsynchronousWindow()
        {
            InitializeComponent();

            this.SynchronizationContext = SynchronizationContext.Current;
        }

        const string DOWNLOAD_URL_100MB = "http://ipv4.download.thinkbroadband.com/100MB.zip";
        const string DOWNLOAD_URL_1GB = "http://ipv4.download.thinkbroadband.com/1GB.zip";

        private void StartDownloadButton_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "Downloading, please wait";
            StartDownloadButton.Enabled = false;

            System.Threading.Thread thread = new System.Threading.Thread(DownloadOnOtherThread);

            thread.Start();
        }

        void DownloadOnOtherThread()
        {

            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                webClient.DownloadData(DOWNLOAD_URL_100MB);
            }

            //// System.InvalidOperationException: 'Cross-thread operation not valid: Control 'MessageLabel' accessed from a thread other than the thread it was created on.'
            //MessageLabel.Text = "Done Downloading";
            //StartDownloadButton.Enabled = true;
            this.SynchronizationContext.Post(ShowCompletedDownloadMessage, null);
        }

        void ShowCompletedDownloadMessage(object state)
        {
            MessageLabel.Text = "Done Downloading";
            StartDownloadButton.Enabled = true;
        }

        const int NUMBER_OF_FILES_TO_DOWNLOAD = 3;

        public SynchronizationContext SynchronizationContext { get; }

        private void StartMultipleDownloadsButton_Click(object sender, EventArgs e)
        {
            StartMultipleDownloadsButton.Enabled = false;
            MessageLabel.Text = "Downloading File #1";


            Thread thread = new Thread(DoDownloadInSeriesOnOtherThread_File1);
            thread.Start();
        }

        void DoDownloadInSeriesOnOtherThread_File1()
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                webClient.DownloadData(DOWNLOAD_URL_100MB);
            }

            SynchronizationContext.Post(DownloadCompleted_File1, null);
        }

        void DownloadCompleted_File1(object state)
        {
            MessageLabel.Text = "Downloading File #2";

            Thread thread = new Thread(DoDownloadInSeriesOnOtherThread_File2);
            thread.Start();
        }

        void DoDownloadInSeriesOnOtherThread_File2()
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                webClient.DownloadData(DOWNLOAD_URL_100MB);
            }

            SynchronizationContext.Post(DownloadCompleted_File2, null);
        }

        void DownloadCompleted_File2(object state)
        {
            MessageLabel.Text = "Downloading File #3";

            Thread thread = new Thread(DoDownloadInSeriesOnOtherThread_File3);
            thread.Start();
        }

        void DoDownloadInSeriesOnOtherThread_File3()
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                webClient.DownloadData(DOWNLOAD_URL_100MB);
            }

            SynchronizationContext.Post(DownloadCompleted_File3, null);
        }

        void DownloadCompleted_File3(object state)
        {
            MessageLabel.Text = "Done Downloading";
            StartMultipleDownloadsButton.Enabled = true;
        }



        int filesRemainingToDownload;

        private void DownloadMultipleInParallelButton_Click(object sender, EventArgs e)
        {

            filesRemainingToDownload = 3;

            DownloadMultipleInParallelButton.Enabled = false;
            MessageLabel.Text = $"Downloading {filesRemainingToDownload} files.";

            Thread thread1, thread2, thread3;

            thread1 = new Thread(DownloadFileOnOtherThreadAgain);
            thread2 = new Thread(DownloadFileOnOtherThreadAgain);
            thread3 = new Thread(DownloadFileOnOtherThreadAgain);


            thread1.Start();
            thread2.Start();
            thread3.Start();
        }

        void DownloadFileOnOtherThreadAgain()
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                webClient.DownloadData(DOWNLOAD_URL_100MB);
            }

            --filesRemainingToDownload;

            this.SynchronizationContext.Post(DownloadInParallelCompleted, null);
        }

        void DownloadInParallelCompleted(object state)
        {
            if (filesRemainingToDownload == 0)
            {
                MessageLabel.Text = "Done Downloading";
                DownloadMultipleInParallelButton.Enabled = true;
            }
            else
            {
                MessageLabel.Text = $"Downloading {filesRemainingToDownload} files.";
            }
        }
    }
}
