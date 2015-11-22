using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using System.Threading;

namespace EC.Droid
{
    [Activity(Label = "En la Cancha", MainLauncher = true, NoHistory = true, Theme = "@android:style/Theme.NoTitleBar")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.SplashView);

            AutoResetEvent autoEvent = new AutoResetEvent(false);
            Timer stateTimer = new Timer((ob) => {
                StartActivity(typeof(MainActivity));
            }, autoEvent, 1000, 0);
        }
    }
}