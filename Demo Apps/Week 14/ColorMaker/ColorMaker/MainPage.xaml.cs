using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ColorMaker
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

        void HandleButton_Click(object sender, EventArgs e)
        {
            this.HSLGrid.IsVisible = !this.HSLGrid.IsVisible;
            this.RGBGrid.IsVisible = !this.RGBGrid.IsVisible;
        }
    }
}
