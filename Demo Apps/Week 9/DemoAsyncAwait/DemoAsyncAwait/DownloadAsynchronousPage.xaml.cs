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
    public partial class DownloadAsynchronousPage : ContentPage
    {
        public DownloadAsynchronousPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            MessageLabel.Text = "Downloading...";


            using (HttpClient client = new HttpClient())
            {
                Byte[] downloadedBytes = await client.GetByteArrayAsync(App.DOWNLOAD_URL_100MB);
            }


            MessageLabel.Text = "Done Downloading!";
        }
    }
}