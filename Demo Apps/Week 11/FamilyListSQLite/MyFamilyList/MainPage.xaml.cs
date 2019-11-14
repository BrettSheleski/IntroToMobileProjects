using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyFamilyList
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;


        public MainPage()
        {
            InitializeComponent();

            viewModel = new MainPageViewModel();

            this.BindingContext = viewModel;

            viewModel.Navigation = this.Navigation;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.UpdateFamilyMembers();
        }
    }
}
