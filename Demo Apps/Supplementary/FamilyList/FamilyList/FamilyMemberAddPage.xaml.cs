using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FamilyList
{
    public partial class FamilyMemberAddPage : ContentPage
    {
        public FamilyMemberAddPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            string firstName, lastName;
            DateTime birthDate;

            // set the above variables
            firstName = FirstNameEntry.Text;
            lastName = LastNameEntry.Text;
            birthDate = BirthDatePicker.Date;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {

                await DisplayAlert("Alert!", "Are you stupid?  Enter a first and last name.", "Moron");

                await DisplayAlert("Nice Job", "Way to click the button", "You smrt");

            }
            else
            {
                FamilyMember familyMember = new FamilyMember
                {
                    FirstName = firstName,
                    LastName = lastName,
                    BirthDate = birthDate
                };

                App.FamilyMemberDatabase.InsertFamilyMember(familyMember);

                await Navigation.PopAsync();
            }

        }
    }
}
