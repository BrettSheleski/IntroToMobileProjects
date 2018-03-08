using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GridDemoLayout
{
    public partial class PersistenceDemo : ContentPage
    {
        public PersistenceDemo()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey(PROPERTY_KEY))
            {
                string persistedValue = Application.Current.Properties[PROPERTY_KEY] as string;

                if (persistedValue != null)
                {
                    ValueEntry.Text = persistedValue;
                }
            }
        }

        const string PROPERTY_KEY = "MyValue";


        protected override void OnDisappearing()
        {
            base.OnDisappearing();


            Application.Current.Properties[PROPERTY_KEY] = ValueEntry.Text;
        }
    }
}
