using Xamarin.Forms;
using System.Collections.Generic;

namespace PizzaOrder3000
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TabPage();
        }

        public static PizzaSize ChosenPizzaSize { get; set; }

        public static List<PizzaTopping> ChosenToppings { get; }
        = new List<PizzaTopping>();

    }
}
