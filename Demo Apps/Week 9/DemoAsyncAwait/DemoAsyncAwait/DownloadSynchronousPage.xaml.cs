using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoAsyncAwait
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DownloadSynchronousPage : ContentPage
    {
        public DownloadSynchronousPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            MessageLabel.Text = "Downloading...";


            // since downloading sychronously is not easy, lets fake it...
            TimeSpan sleepTime = TimeSpan.FromSeconds(20);
            Task.Delay(sleepTime).Wait();



            MessageLabel.Text = "Done Downloading!";
        }
    }
}