using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FeedReader
{
    public class HyperlinkLabel : Label
    {
        public HyperlinkLabel()
        {
            GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(OpenBrowser) });
        }

        void OpenBrowser()
        {
            if (this.Uri != null)
            {
                Device.OpenUri(Uri);
            }
        }

        //public static readonly BindableProperty UriProperty = BindableProperty.Create<HyperlinkLabel, Uri>(x => x.Uri, null, BindingMode.TwoWay, null, UriPropertyChanged);
        public static readonly BindableProperty UriProperty = BindableProperty.Create("Uri", typeof(Uri), typeof(HyperlinkLabel), null, BindingMode.TwoWay, null, OnUriPropertyChanged);

        public Uri Uri
        {
            get
            {
                return (Uri)GetValue(UriProperty);
            }
            set
            {
                SetValue(UriProperty, value);
            }
        }

        private static void OnUriPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((HyperlinkLabel)bindable).OnUriChanged((Uri)oldValue, (Uri)newValue);
        }

        protected virtual void OnUriChanged(Uri oldValue, Uri newValue)
        {
        }
    }
}
