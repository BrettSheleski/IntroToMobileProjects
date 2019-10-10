using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PizzaOrderer5001
{
    public partial class PizzaSizePage : ContentPage
    {
        public PizzaSizePage()
        {
            InitializeComponent();
        }

        void HandleSmallButton_Clicked(object sender, EventArgs e)
        {
            App.ChosenPizzaSize = PizzaSize.Small;

            NavigateToSecondTab();
        }

        void HandleMediumButton_Clicked(object sender, EventArgs e)
        {
            App.ChosenPizzaSize = PizzaSize.Medium;

            NavigateToSecondTab();
        }

        void HandleLargeButton_Clicked(object sender, EventArgs e)
        {
            App.ChosenPizzaSize = PizzaSize.Large;

            NavigateToSecondTab();
        }

        void NavigateToSecondTab()
        {
            TabbedPage theTabbedPage = (TabbedPage)App.Current.MainPage;


            theTabbedPage.CurrentPage = theTabbedPage.Children[1];

        }
    }
}
