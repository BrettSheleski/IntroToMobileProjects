using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PizzaOrder3000
{
    public partial class TabPage : TabbedPage
    {
        /*
        SelectSizePage TheFirstPage { get; set; }
        ToppingsPage TheSecondPage { get; set; }
        ReviewPage TheThirdPage { get; set; }
        */
        public TabPage()
        {
            InitializeComponent();

            /*
            TheFirstPage = new SelectSizePage();
            TheSecondPage = new ToppingsPage();
            TheThirdPage = new ReviewPage();

            TheFirstPage.Title = "Choose your size";
            TheSecondPage.Title = "Choose your toppings";
            TheThirdPage.Title = "Reivew your order";

            this.Children.Add(TheFirstPage);
            this.Children.Add(TheSecondPage);
            this.Children.Add(TheThirdPage);
            */

        }
    }
}
