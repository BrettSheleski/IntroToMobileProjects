using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PizzaOrder3000
{
    public partial class ReviewPage : ContentPage
    {
        public ReviewPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            UpdateTheTextAndStuff();

            base.OnAppearing();
        }

        private void UpdateTheTextAndStuff()
        {

            string sizeString;
            double totalPrice = 0;

            if (App.ChosenPizzaSize == PizzaSize.Small){
                sizeString = "Small";
                totalPrice = 10;
            }
            else if (App.ChosenPizzaSize == PizzaSize.Medium){
                sizeString = "Medium";
                totalPrice = 15;
            }
            else{
                sizeString = "Large";
                totalPrice = 20;
            }

            PizzaSizeLabel.Text = sizeString;

            ToppingsStackLayout.Children.Clear();

            Label toppingLabel;

            foreach(var topping in App.ChosenToppings){

                toppingLabel = new Label() { Text = topping.Name };

                ToppingsStackLayout.Children.Add(toppingLabel);

                totalPrice += topping.Price;
            }

            TotalPriceLabel.Text = totalPrice.ToString("c");
        }

        void HandleSubmitButton_Clicked(object sender, System.EventArgs e)
        {
            string message = "Order Submitted, your card has been charged $400 (lots of gratuity).";

            DisplayAlert("Order Completed", message, "Sweet.");

        }
    }
}
