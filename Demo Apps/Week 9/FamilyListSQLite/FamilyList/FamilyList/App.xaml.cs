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

        private static SQLite.SQLiteDatabase _database;

        public static SQLite.SQLiteDatabase Database{
            get{

                if (_database == null){
                    _database = new SQLite.SQLiteDatabase();
                }

                return _database;
            }
        }
	}
}
