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

        protected override void OnStart()
        {
            base.OnStart();

            LoadFamilyFromProperties();
        }

        protected override void OnResume()
        {
            base.OnResume();

            LoadFamilyFromProperties();
        }

        protected override void OnSleep()
        {
            base.OnSleep();

            SaveFamilyToProperties();
        }

        const string FAMILY_MEMBERS_PROPERTIES_KEY = "FamilyMembers";

        public static void LoadFamilyFromProperties()
        {
            FamilyMembers.Clear();

            if (Application.Current.Properties.ContainsKey(FAMILY_MEMBERS_PROPERTIES_KEY))
            {
                string json = Application.Current.Properties[FAMILY_MEMBERS_PROPERTIES_KEY] as string;

                if (json != null)
                {
                    List<FamilyMember> theFam = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FamilyMember>>(json);

                    FamilyMembers.AddRange(theFam);
                }
            }
        }

        public static void SaveFamilyToProperties()
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(FamilyMembers);

            Application.Current.Properties[FAMILY_MEMBERS_PROPERTIES_KEY] = json;
        }

        public static List<FamilyMember> FamilyMembers { get; } = new List<FamilyMember>();
	}
}
