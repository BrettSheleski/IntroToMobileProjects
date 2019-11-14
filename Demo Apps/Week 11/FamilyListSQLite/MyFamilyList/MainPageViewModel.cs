using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MyFamilyList
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
            this.PersonRepository = new PersonRepository();

            AddCommand = new Command(Add);


            UpdateFamilyMembers();



        }


        public PersonRepository PersonRepository { get; }

        public ObservableCollection<Person> FamilyMembers { get; } = new ObservableCollection<Person>();

        public Command AddCommand { get; }

        public Xamarin.Forms.INavigation Navigation { get; set; }

        void Add()
        {
            AddFamilyMemberPage page = new AddFamilyMemberPage();

            AddFamilyMemberViewModel viewModel = new AddFamilyMemberViewModel();

            viewModel.Navigation = this.Navigation;


            page.BindingContext = viewModel;

            Navigation.PushAsync(page);


            // do something here!
        }

        public void UpdateFamilyMembers()
        {
            this.FamilyMembers.Clear();

            foreach (var person in this.PersonRepository.GetAllPeople())
            {
                this.FamilyMembers.Add(person);
            }
        }

    }
}
