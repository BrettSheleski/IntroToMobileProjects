using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FamilyList
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FamilyListPage : ContentPage
	{
		public FamilyListPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            // we need to make sure the ItemsSource is changed

            // If we are navigating back to this page, the ItemsSource is already set to the list
            // and therefore the visuals will not update

            // so set to something (null) then (back) to the list of FamilyMembers
            FamilyListView.ItemsSource = null;
            FamilyListView.ItemsSource = App.FamilyMembers;

            base.OnAppearing();
        }

        private void AddFamilyMemberButton_Clicked(object sender, EventArgs e)
        {
            var addPage = new AddFamilyMemberPage();

            Navigation.PushAsync(addPage);
        }
    }
}