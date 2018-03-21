using Xamarin.Forms;

namespace DemoAsyncAwait
{
    public partial class DemoAsyncAwaitPage : ContentPage
    {
        public DemoAsyncAwaitPage()
        {
            InitializeComponent();
        }

        private void SynchronousButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new DownloadSynchronousPage());
        }

        private void AsynchronousButton_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new DownloadAsynchronousPage());
        }
    }
}
