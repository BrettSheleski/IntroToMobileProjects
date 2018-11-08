using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PokeAwesome
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var pokemonPickerPage = new MainPage();

            MainPage = new NavigationPage(pokemonPickerPage);
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
