using System;
namespace PizzaOrder3000
{
    public class PizzaTopping
    {
        public string Name { get; set; }

        public double Price { get; set; }


        public static PizzaTopping Pepperoni { get; } 
        = new PizzaTopping { Name = "Pepperoni", Price = 1.0 };

        public static PizzaTopping Sausage { get; } 
        = new PizzaTopping { Name = "Sausage", Price = 1.0 };

        public static PizzaTopping Mushroom { get; } 
        = new PizzaTopping { Name = "Mushroom", Price = 1.0 };


    }
}
