using Xamarin.Forms;

namespace TheGreatTemperatureConverter
{
    public partial class TheGreatTemperatureConverterPage : ContentPage
    {

        CarouselView theCarousel;

        public TheGreatTemperatureConverterPage()
        {
            InitializeComponent();


            TemperatureConverter celsiusToF = new TemperatureConverter
            {
                Title = "Celsius To Fahrenheit??",
                ConverterDelegate = c => (c * (9/5.0)) + 32
            };

            TemperatureConverter fToCelsius = new TemperatureConverter
            {
                Title = "Fahrenheight to Celsius",
                ConverterDelegate = f => (f - 32) * (5 / 9.0)
            };

            TemperatureConverter[] converters = new TemperatureConverter[]{celsiusToF, fToCelsius };

            TheCarousel.ItemsSource = converters;
        }



    }
}
