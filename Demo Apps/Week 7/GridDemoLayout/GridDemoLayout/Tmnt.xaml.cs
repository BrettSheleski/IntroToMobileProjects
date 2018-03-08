using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GridDemoLayout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tmnt : ContentPage
    {
        public Tmnt()
        {
            InitializeComponent();


            Random random = new Random((int)DateTime.Now.Ticks);


            List<TurtleInfo> turtles = new List<TurtleInfo>();

            turtles.Add(new TurtleInfo
            {
                Name = "Leonardo",
                ImageSource = "tmntLeo.jpg",
                Rotation = random.Next(-30, 31)
            });

            turtles.Add(new TurtleInfo
            {
                Name = "Donatello",
                ImageSource = "tmntDon.jpg",
                Rotation = random.Next(-30, 31)
            });

            turtles.Add(new TurtleInfo
            {
                Name = "Michelangelo",
                ImageSource = "tmntMikey.png",
                Rotation = random.Next(-30, 31)
            });

            turtles.Add(new TurtleInfo
            {
                Name = "Raphael",
                ImageSource = "tmntRaph.png",
                Rotation = random.Next(-30, 31)
            });

            this.TheCarousel.ItemsSource = turtles;


            PizzaImage.GestureRecognizers.Add(new TapGestureRecognizer(v => DisplayAlert("Alert", "Cowabunga!", "OK")));
        }

    }
}