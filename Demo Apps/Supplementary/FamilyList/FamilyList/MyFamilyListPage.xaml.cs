using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FamilyList
{
    public partial class MyFamilyListPage : ContentPage
    {
        public MyFamilyListPage()
        {
            InitializeComponent();

        }

        async void HandleAddButtonClick(object sender, EventArgs e){

            FamilyMemberAddPage nextPage = new FamilyMemberAddPage();

            //AddButton.IsEnabled = false;

            await Navigation.PushAsync(nextPage);

            AddButton.IsEnabled = true;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            FamilyListView.ItemsSource = null;
            FamilyListView.ItemsSource = App.FamilyMemberDatabase.GetAllFamilyMembers();
        }
    }
}
