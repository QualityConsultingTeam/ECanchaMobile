using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;
using Xamarin.Forms.Platform.Android;
using Gcm.Client;
using Android.Content;

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

			RegisterNotifications ();
            
        }

       
        private void RegisterNotifications()
		{
			try
			{
				// Check to ensure everything's setup right
				GcmClient.CheckDevice(this);
				GcmClient.CheckManifest(this);

				// Register for push notifications
				System.Diagnostics.Debug.WriteLine("Registering...");
				GcmClient.Register(this, PushHandlerBroadcastReceiver.SENDER_IDS);
			}
			catch (Java.Net.MalformedURLException)
			{
				CreateAndShowDialog(new Exception("There was an error creating the Mobile Service. Verify the URL"), "Error");
			}
			catch (Exception e)
			{
				CreateAndShowDialog(e, "Error");
			}
		}


		void CreateAndShowDialog(Exception exception, String title)
		{
			CreateAndShowDialog(exception.Message, title);
		}

		void CreateAndShowDialog(string message, string title)
		{
			AlertDialog.Builder builder = new AlertDialog.Builder(this);

			builder.SetMessage(message);
			builder.SetTitle(title);
			builder.SetIcon(Resource.Drawable.ic_launcher);
			builder.Create().Show();
		}
        //static MainActivity instance;


        
    }


}

