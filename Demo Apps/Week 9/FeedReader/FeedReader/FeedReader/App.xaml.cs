using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FeedReader.FeedListMvvm;
using Xamarin.Forms;

namespace FeedReader
{
    public partial class App : Application
    {
        public ViewModel ViewModel { get; }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FeedListMvvm.FeedListMvvmPage { BindingContext = new FeedListMvvm.ViewModel() });
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
