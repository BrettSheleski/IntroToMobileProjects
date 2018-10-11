using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PizzaOrder3000
{
    public partial class SelectSizePage : ContentPage
    {
        public SelectSizePage()
        {
            InitializeComponent();
        }

        void HandleSmall_Clicked(object sender, System.EventArgs e)
        {
            App.ChosenPizzaSize = PizzaSize.Small;

            NavigateToNextPage();
        }


        void HandleMedium_Clicked(object sender, System.EventArgs e)
        {
            App.ChosenPizzaSize = PizzaSize.Medium;

            NavigateToNextPage();
        }

        void HandleLarge_Clicked(object sender, System.EventArgs e)
        {
            App.ChosenPizzaSize = PizzaSize.Large;

            NavigateToNextPage();
        }

        void NavigateToNextPage(){

            TabPage theTabPage = (TabPage)App.Current.MainPage;

            theTabPage.CurrentPage = theTabPage.Children[1];
        }
    }
}
