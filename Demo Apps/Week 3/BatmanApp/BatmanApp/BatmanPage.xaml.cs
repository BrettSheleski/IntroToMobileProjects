using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BatmanApp
{
    public partial class BatmanPage : TabbedPage
    {
        public BatmanPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            JokerPage page = new JokerPage();

            Navigation.PushAsync(page);
        }
    }
}
