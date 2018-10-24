using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace FamilyList
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();


            FamilyListPage listPage = new FamilyListPage();

            NavigationPage navPage = new NavigationPage(listPage);

            MainPage = navPage;
		}

        public static List<FamilyMember> FamilyMembers { get; } = new List<FamilyMember>();
	}
}
