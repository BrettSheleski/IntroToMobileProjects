using System;
using Xamarin.Forms;

namespace GridDemoLayout
{
    public partial class GridDemoLayoutPage : ContentPage
    {
        public GridDemoLayoutPage()
        {
            InitializeComponent();
        }

        async void HandleShowFlagXaml_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FlagPage());
        }

        async void HandleShowFlagCS_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FlagPageCS());
        }

        async void HandleTmnt_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Tmnt());
        }
    }
}
