using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Xamarin.Forms.Platform.Android;

namespace EC.Droid
{
    [Activity(Label = "En la Cancha Club", 
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
        
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            ToolbarResource = Resource.Layout.toolbar;
            TabLayoutResource = Resource.Layout.tabs;



            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            ImageCircleRenderer.Init();
            LoadApplication(new EC.Forms.App());
            
        }
    }
}

