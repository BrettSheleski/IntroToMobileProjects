using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace WeatherHub.Xamarin
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            var mainPage = new MainPage();

            IWeatherProvider provider = new WeatherHub.OpenWeatherMap.OpenWeatherMapProvider("b9c77fa53374b9861bc3f87d684feb3a");
            var model = new WeatherHub.Models.ViewWeatherPageModel(provider);
            var vm = new Models.ViewWeatherPageViewModel(model);

            mainPage.BindingContext = vm;

            MainPage = mainPage;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
