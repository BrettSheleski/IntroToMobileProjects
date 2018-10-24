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
	public partial class AddFamilyMemberPage : ContentPage
	{
		public AddFamilyMemberPage ()
		{
			InitializeComponent ();
		}

        private void AddFamilyMember_Clicked(object sender, EventArgs e)
        {
            string firstName, lastName;
            DateTime birthDate;

            firstName = FirstNameEntry.Text;
            lastName = LastNameEntry.Text;

            birthDate = BirthDatePicker.Date;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                DisplayAlert("Uh oh!", "Please specify a first and last name and try again.", "Try Again");
            }
            else
            {
                FamilyMember familyMember = new FamilyMember();
                familyMember.FirstName = firstName;
                familyMember.LastName = lastName;
                familyMember.BirthDate = birthDate;

                App.FamilyMembers.Add(familyMember);

                Navigation.PopAsync();
            }

        }
    }
}