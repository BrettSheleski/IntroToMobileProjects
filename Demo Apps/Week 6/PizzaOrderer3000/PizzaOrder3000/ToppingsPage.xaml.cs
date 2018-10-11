using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PizzaOrder3000
{
    public partial class ToppingsPage : ContentPage
    {
        public ToppingsPage()
        {
            InitializeComponent();
        }

        void HandlePepperoni_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (PepperoniSwitch.IsToggled){
                App.ChosenToppings.Add(PizzaTopping.Pepperoni);
            }
            else{
                App.ChosenToppings.Remove(PizzaTopping.Pepperoni);
            }
        }

        void HandleSausage_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (SausageSwitch.IsToggled)
            {
                App.ChosenToppings.Add(PizzaTopping.Sausage);
            }
            else
            {
                App.ChosenToppings.Remove(PizzaTopping.Sausage);
            }
        }

        void HandleMushroom_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            if (MushroomSwitch.IsToggled)
            {
                App.ChosenToppings.Add(PizzaTopping.Mushroom);
            }
            else
            {
                App.ChosenToppings.Remove(PizzaTopping.Mushroom);
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            NavigateToNextPage();
        }

        private void NavigateToNextPage()
        {
            TabPage theTabPage = (TabPage)App.Current.MainPage;

            theTabPage.CurrentPage = theTabPage.Children[2];
        }
    }
}
