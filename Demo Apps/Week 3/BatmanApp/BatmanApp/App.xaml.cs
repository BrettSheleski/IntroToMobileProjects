﻿using Xamarin.Forms;

namespace BatmanApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            StartPage startPage = new StartPage();

            NavigationPage navPage = new NavigationPage(startPage);


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
