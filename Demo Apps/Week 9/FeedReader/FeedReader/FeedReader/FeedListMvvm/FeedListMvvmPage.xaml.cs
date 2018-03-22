using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeedReader.FeedListMvvm
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FeedListMvvmPage : ContentPage
	{
		public FeedListMvvmPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (this.BindingContext is ViewModel) {
                await ((ViewModel)BindingContext).InitializeAsync();
            }
        }
    }
}