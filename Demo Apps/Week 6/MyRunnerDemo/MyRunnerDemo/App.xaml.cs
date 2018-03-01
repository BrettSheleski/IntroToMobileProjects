using Xamarin.Forms;

namespace MyRunnerDemo
{
    public partial class App : Application
    {
        public static RunCalculator RunCalcator { get; } = new RunCalculator();

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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
