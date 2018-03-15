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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool isFirstDownloadCompleted = false;
        bool isSecondDownloadCompleted = false;
        bool isThirdDownloadCompleted = false;

        private void button1_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "Downloading Stuff, please wait.";

            isFirstDownloadCompleted = false;
            isSecondDownloadCompleted = false;
            isThirdDownloadCompleted = false;

            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += BackgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();

            BackgroundWorker bw2 = new BackgroundWorker();
            bw2.DoWork += Bw2_DoWork;
            bw2.RunWorkerCompleted += Bw2_RunWorkerCompleted;
            bw2.RunWorkerAsync();

            BackgroundWorker bw3 = new BackgroundWorker();
            bw3.DoWork += Bw3_DoWork;
            bw3.RunWorkerCompleted += Bw3_RunWorkerCompleted;
            bw3.RunWorkerAsync();

        }

        private void Bw3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowCompletedMessage();
        }

        private void Bw3_DoWork(object sender, DoWorkEventArgs e)
        {
            DownloadAThirdLargeFile();
            isThirdDownloadCompleted = true;
        }

        private void Bw2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowCompletedMessage();
        }

        private void ShowCompletedMessage()
        {
            if (isFirstDownloadCompleted && isSecondDownloadCompleted && isThirdDownloadCompleted)
            {
                MessageLabel.Text = "Done Downloading, yahoo!";
            }
        }

        private void Bw2_DoWork(object sender, DoWorkEventArgs e)
        {
            DownloadAnotherLargeFile();
            isSecondDownloadCompleted = true;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowCompletedMessage();
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DownloadLargeFile();

            isFirstDownloadCompleted = true;
        }

        private Task DownloadAThirdLargeFileAsync()
        {
            return Task.Factory.StartNew(DownloadAThirdLargeFile);
        }

        private void DownloadAThirdLargeFile()
        {
            // not actually downloading large file
            // simulating downloading large file by 
            // locking up the current thread

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));
        }

        private Task DownloadAnotherLargeFileAsyc()
        {
            return Task.Factory.StartNew(DownloadAnotherLargeFile);
        }

        private void DownloadAnotherLargeFile()
        {
            // not actually downloading large file
            // simulating downloading large file by 
            // locking up the current thread

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        private Task DownloadLargeFileAsync()
        {
            return Task.Factory.StartNew(DownloadLargeFile);
        }

        private void DownloadLargeFile()
        {
            // not actually downloading large file
            // simulating downloading large file by 
            // locking up the current thread

            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "Downloading Stuff, please wait.";
            
            await Task.WhenAll(
                DownloadLargeFileAsync(), 
                DownloadAnotherLargeFileAsyc(), 
                DownloadAThirdLargeFileAsync()
            );
  
            MessageLabel.Text = "Done.  yay!";
        }


        


        public async Task DoSomethingAsync(string arg1, int count, CancellationToken cancellationToken, IProgress<double> progress)
        {
            for(int i = 0; i < count; ++i)
            {
                await Task.Delay(10);
                
                if (cancellationToken.IsCancellationRequested)
                    break;
                else
                    progress.Report(i / (double)count);
            }
        }

        CancellationTokenSource _cancellationTokenSource;

        private async void button3_Click(object sender, EventArgs e)
        {
            TheProgressBar.Minimum = 0;
            TheProgressBar.Maximum = 100;
            Progress<double> progress = new Progress<double>(d => {
                TheProgressBar.Value = (int)(d * 100);
            });


            _cancellationTokenSource = new CancellationTokenSource();
            await DoSomethingAsync("", 2000, _cancellationTokenSource.Token, progress);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();

            TheProgressBar.Value = 0;
        }
    }
}
