using AudioManager;
using Xamarin.Forms;

namespace UndehydrationCalculator
{
    public partial class UndehydrationCalculatorPage : ContentPage
    {
        public UndehydrationCalculatorPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Audio.Manager.PlaySound("SampleAudio.mp3");
        }
    }
}
