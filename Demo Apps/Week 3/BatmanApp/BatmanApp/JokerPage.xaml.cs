using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BatmanApp
{
    public partial class JokerPage : MasterDetailPage
    {
        public JokerPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {


            this.IsPresented = !this.IsPresented;
        }
    }
}
