using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BatmanApp
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        void Batman_Clicked(object sender, System.EventArgs e)
        {
            BatmanPage page = new BatmanPage();

            Navigation.PushAsync(page);
        }

        void Joker_Clicked(object sender, System.EventArgs e)
        {
            JokerPage page = new JokerPage();

            Navigation.PushAsync(page);
        }
    }
}
