﻿using Xamarin.Forms;

namespace DemoAsyncAwait
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new DemoAsyncAwaitPage());
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

        public const string DOWNLOAD_URL_100MB = "https://speed.hetzner.de/100MB.bin";
    }
}
