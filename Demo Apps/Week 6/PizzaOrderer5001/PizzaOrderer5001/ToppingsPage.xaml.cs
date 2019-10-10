using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PizzaOrderer5001
{
    public partial class ToppingsPage : ContentPage
    {
        public ToppingsPage()
        {
            InitializeComponent();

            ToppingsListView.ItemsSource = App.PizzaToppings;
        }

    }
}
