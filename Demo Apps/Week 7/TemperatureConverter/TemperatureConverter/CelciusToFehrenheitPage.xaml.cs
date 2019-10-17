using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TemperatureConverter
{
    public partial class CelciusToFehrenheitPage : ContentPage
    {
        public CelciusToFehrenheitPage()
        {
            InitializeComponent();
        }


        const double nineFifths = 9 / 5.0;

        void HandleCalculateButton_Click(object sender, EventArgs e)
        {
            string degreesCString = CelciusEntry.Text;

            double degreesC;

            if (double.TryParse(degreesCString, out degreesC))
            {
                double degreesF = 32 + (nineFifths * degreesC);

                FahrenheitEntry.Text = degreesF.ToString();
            }
        }
    }
}
