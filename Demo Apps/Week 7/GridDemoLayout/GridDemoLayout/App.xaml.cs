using Xamarin.Forms;

namespace GridDemoLayout
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Page firstPage = new GridDemoLayoutPage();

            NavigationPage navPage = new NavigationPage(firstPage);

            MainPage = navPage;

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
