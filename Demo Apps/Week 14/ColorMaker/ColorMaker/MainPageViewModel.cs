using System;
using Xamarin.Forms;

namespace ColorMaker
{
    public class MainPageViewModel : ViewModel
    {
        private Color color;
        private double red;
        private double green;
        private double blue;
        private double alpha;

        public Color Color { get => color; set => Set(ref color, value, UpdateComponentsFromColor); }

        public double Red { get => red; set => Set(ref red, value, UpdateColorFromRGBA); }

        public double Green { get => green; set => Set(ref green, value, UpdateColorFromRGBA); }

        public double Blue { get => blue; set => Set(ref blue, value, UpdateColorFromRGBA); }



        public double Hue { get => hue; set => Set(ref hue , value, UpdateColorFromHSLA); }

        public double Saturation { get => saturation; set => Set(ref saturation, value, UpdateColorFromHSLA); }

        public double Luminosity { get => luminosity; set => Set(ref luminosity, value, UpdateColorFromHSLA); }



        public double Alpha { get => alpha; set => Set(ref alpha, value, UpdateColorFromRGBA); }


        bool isUpdatingColor = false;
        private double hue;
        private double saturation;
        private double luminosity;

        void UpdateColorFromRGBA()
        {
            if (!isUpdatingColor)
            {
                isUpdatingColor = true;

                this.Color = Color.FromRgba(this.Red, this.Green, this.Blue, this.Alpha);

                this.Hue = this.Color.Hue;
                this.Saturation = this.Color.Saturation;
                this.Luminosity = this.Color.Luminosity;

                isUpdatingColor = false;
            }
        }

        void UpdateColorFromHSLA()
        {
            if (!isUpdatingColor)
            {
                isUpdatingColor = true;

                this.Color = Color.FromHsla(this.Hue, this.Saturation, this.Luminosity, this.Alpha);

                this.Red = this.Color.R;
                this.Blue = this.Color.B;
                this.Green = this.Color.G;
                this.Alpha = this.Color.A;

                isUpdatingColor = false;
            }
        }

        void UpdateComponentsFromColor()
        {
            if (!isUpdatingColor)
            {
                isUpdatingColor = true;

                this.Red = this.Color.R;
                this.Green = this.Color.G;
                this.Blue = this.Color.B;
                this.Alpha = this.Color.A;

                isUpdatingColor = false;
            }

        }


    }
}
