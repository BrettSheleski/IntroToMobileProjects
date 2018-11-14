using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace GamepadTester.Droid
{
    [Activity(Label = "GamepadTester", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public GamepadService GamepadService { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Xamarin.Forms.DependencyService.Register<GamepadService>();

            this.GamepadService = Xamarin.Forms.DependencyService.Get<GamepadService>(Xamarin.Forms.DependencyFetchTarget.GlobalInstance);

            LoadApplication(new App());
        }

        public override bool OnGenericMotionEvent(MotionEvent e)
        {
            return this.GamepadService.HandleMotionEvent(e);
        }
    }
}

