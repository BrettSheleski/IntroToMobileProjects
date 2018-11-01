using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FamilyList
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MyFamilyListPage listPage = new MyFamilyListPage();

            NavigationPage navPage = new NavigationPage(listPage);

            MainPage = navPage;
        }


        public static FamilyMemberDatabase FamilyMemberDatabase { get; } = new FamilyMemberDatabase();


    }
}
