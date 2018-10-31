using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

            using (HttpClient client = new HttpClient())
            {
                client.GetByteArrayAsync(App.DOWNLOAD_URL_100MB).Wait();
            }


            MessageLabel.Text = "Done Downloading!";
        }
    }
}