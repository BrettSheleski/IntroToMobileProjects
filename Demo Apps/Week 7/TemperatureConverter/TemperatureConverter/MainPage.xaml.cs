using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TemperatureConverter
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void HandlC2F_Clicked(object sender, EventArgs e)
        {
            CelciusToFehrenheitPage page = new CelciusToFehrenheitPage();

            Navigation.PushAsync(page);
        }

        void HandlF2C_Clicked(object sender, EventArgs e)
        {

        }

    }
}
