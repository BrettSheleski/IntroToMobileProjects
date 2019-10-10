using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PizzaOrderer5001
{
    public partial class SummaryPage : ContentPage
    {
        public SummaryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {

            double totalCost = 0;

            switch (App.ChosenPizzaSize)
            {
                case PizzaSize.Small:
                    totalCost += 10;
                    PizzaSizeLabel.Text = "Small";
                    break;
                case PizzaSize.Medium:
                    totalCost += 15;
                    PizzaSizeLabel.Text = "Medium";
                    break;
                case PizzaSize.Large:
                    totalCost += 20;
                    PizzaSizeLabel.Text = "Large";
                    break;
            }

            List<PizzaTopping> selectedToppings = new List<PizzaTopping>();

            foreach (var topping in App.PizzaToppings)
            {
                if (topping.IsSelected)
                {
                    totalCost += topping.Cost;
                    selectedToppings.Add(topping);
                }
            }

            SelectedToppingsList.ItemsSource = selectedToppings;

            TotalCostLabel.Text = totalCost.ToString("c");


            base.OnAppearing();
        }

        void PlaceOrderButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Order Placed", "Your credit card was charged $75757575.00 (with gratuity)", "Ok");
        }
    }
}
