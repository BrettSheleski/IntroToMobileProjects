using System;
using Xamarin.Forms;

namespace MyFamilyList
{
    public class AddFamilyMemberViewModel
    {
        public AddFamilyMemberViewModel()
        {
            this.PersonRepository = new PersonRepository();


            SaveCommand = new Command(Save);
        }

        public PersonRepository PersonRepository { get; }

        public Person FamilyMember { get; set; } = new Person();

        public Command SaveCommand { get; }

        public Xamarin.Forms.INavigation Navigation { get; set; }

        void Save()
        {
            // do stuff

            this.PersonRepository.SaveNewPerson(this.FamilyMember);


            // navigate back
            Navigation.PopAsync();
        }

    }
}
