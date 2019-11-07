using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyFamilyList
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            AddCommand = new Command(Add);

            FamilyMembers.Add(new Person
            {
                FirstName = "Brett",
                LastName = "Awesomeski",
                BirthDate = new DateTime(1984, 2, 12)
            });


            FamilyMembers.Add(new Person
            {
                FirstName = "Sarah",
                LastName = "Sheleski",
                BirthDate = new DateTime(1980, 5, 6)
            });

            FamilyMembers.Add(new Person
            {
                FirstName = "Steven",
                LastName = "Sheleski",
                BirthDate = new DateTime(2016, 2, 14)
            });

            FamilyMembers.Add(new Person
            {
                FirstName = "Gaby",
                LastName = "Dilley",
                BirthDate = new DateTime(2008, 1, 11)
            });
        }


        public List<Person> FamilyMembers { get; } = new List<Person>();

        public Command AddCommand { get; } 

        public Xamarin.Forms.INavigation Navigation { get; set; }

        void Add()
        {
            AddFamilyMemberPage page = new AddFamilyMemberPage();

            Navigation.PushAsync(page);


            // do something here!
        }

    }
}
