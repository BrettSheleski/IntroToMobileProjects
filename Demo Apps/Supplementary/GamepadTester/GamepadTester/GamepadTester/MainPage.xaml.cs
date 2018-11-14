using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GamepadTester
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            IGamepadService gamepadService = DependencyService.Get<IGamepadService>(DependencyFetchTarget.GlobalInstance);

            var gamepads = gamepadService.GetGamepads();

            this.GamepadListView.ItemsSource = gamepads;
        }

        private void GamepadListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.SelectButton.IsEnabled = e.SelectedItem != null;
        }

         private async void SelectButton_Clicked(object sender, EventArgs e)
        {
            if (this.GamepadListView.SelectedItem is GamepadModel gamepadModel)
            {
                var nextpage = new GamepadPage();

                nextpage.BindingContext = gamepadModel;

                await Navigation.PushAsync(nextpage);
            }
        }
    }
}
