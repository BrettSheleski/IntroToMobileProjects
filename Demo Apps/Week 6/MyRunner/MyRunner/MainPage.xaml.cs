using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MyRunner
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();


            if (Device.RuntimePlatform == Device.iOS)
            {
                Run1Page.Icon = new FileImageSource
                {
                    File = "Runner1"
                };

                Run2Page.Icon = new FileImageSource
                {
                    File = "Runner2"
                };

                Run3Page.Icon = new FileImageSource
                {
                    File = "Runner3"
                };

                ReviewPage.Icon = new FileImageSource
                {
                    File = "RunnerFinish"
                };
            }

        

        }



    }
}
