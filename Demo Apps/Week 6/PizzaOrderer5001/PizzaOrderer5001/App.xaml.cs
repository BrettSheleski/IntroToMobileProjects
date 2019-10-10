using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;

namespace PizzaOrderer5001
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MyTabPage();


            PizzaToppings.Add(new PizzaTopping
            {
                Name = "Green Peppers",
                Cost = 0.5
            });

            PizzaToppings.Add(new PizzaTopping
            {
                Name = "Cucumbers",
                Cost = 1.5
            });

            PizzaToppings.Add(new PizzaTopping
            {
                Name = "Pineapple",
                Cost = 2
            });


            PizzaToppings.Add(new PizzaTopping
            {
                Name = "Artichoke",
                Cost = 10
            });

            PizzaToppings.Add(new PizzaTopping
            {
                Name = "Motor Oil",
                IsSelected = true,
                Cost = 4
            });

            PizzaToppings.Add(new PizzaTopping
            {
                Name = "Bleach",
                Cost = 0
            });
        }

        public static PizzaSize ChosenPizzaSize { get; set; }

        public static List<PizzaTopping> PizzaToppings { get; } = new List<PizzaTopping>();
        
    }
}
