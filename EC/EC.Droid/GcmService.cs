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
using Android.Util;
using Gcm.Client;

using System.Diagnostics;
using WindowsAzure.Messaging;
using Android.Support.V4.App;
using TaskStackBuilder = Android.Support.V4.App.TaskStackBuilder;

[assembly: Permission(Name = "enlacancha.com.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "enlacancha.com.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]

//GET_ACCOUNTS is only needed for android versions 4.0.3 and below
[assembly: UsesPermission(Name = "android.permission.GET_ACCOUNTS")]
[assembly: UsesPermission(Name = "android.permission.INTERNET")]
[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]

namespace EC.Droid
{
    //You must subclass this!
    [BroadcastReceiver(Permission = Gcm.Client.Constants.PERMISSION_GCM_INTENTS)]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_MESSAGE }, Categories = new string[] { "enlacancha.com" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_REGISTRATION_CALLBACK }, Categories = new string[] { "enlacancha.com" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_LIBRARY_RETRY }, Categories = new string[] { "enlacancha.com" })]
    public class PushHandlerBroadcastReceiver : GcmBroadcastReceiverBase<GcmService>
    {
        //IMPORTANT: Change this to your own Sender ID!
        //The SENDER_ID is your Google API Console App Project ID.
        //  Be sure to get the right Project ID from your Google APIs Console.  It's not the named project ID that appears in the Overview,
        //  but instead the numeric project id in the url: eg: https://code.google.com/apis/console/?pli=1#project:785671162406:overview
        //  where 785671162406 is the project id, which is the SENDER_ID to use!
        public static string[] SENDER_IDS = new string[] { Constants.SenderID };

        public const string TAG = "GoogleCloudMessaging";
    }

    [Service] //Must use the service tag
    public class GcmService : GcmServiceBase
    {
        public static string RegistrationID { get; private set; }

        public GcmService()
            : base(PushHandlerBroadcastReceiver.SENDER_IDS)
        {
            Log.Info(PushHandlerBroadcastReceiver.TAG, "GcmService() constructor");
        }

        protected override void OnRegistered(Context context, string registrationId)
        {


            Log.Verbose(PushHandlerBroadcastReceiver.TAG, "GCM Registered: " + registrationId);
            RegistrationID = registrationId;

            //createNotification("PushHandlerService-GCM Registered...", "The device has been Registered!");

            Hub = new NotificationHub(Constants.NotificationHubName, Constants.ListenConnectionString,
                                        context);
            try
            {
                Hub.UnregisterAll(registrationId);
            }
            catch (Exception ex)
            {
                Log.Error(PushHandlerBroadcastReceiver.TAG, ex.Message);
            }

            //var tags = new List<string>() { "falcons" }; // create tags if you want
            var tags = new List<string>() { };

            try
            {
                var hubRegistration = Hub.Register(registrationId, tags.ToArray());
            }
            catch (Exception ex)
            {
                Log.Error(PushHandlerBroadcastReceiver.TAG, ex.Message);
            }

        }

        

        protected override void OnUnRegistered(Context context, string registrationId)
        {
            Log.Verbose(PushHandlerBroadcastReceiver.TAG, "GCM Unregistered: " + registrationId);
            //createNotification("GcmService Unregistered...", "The device has been unregistered, Tap to View!");
        }

        protected override void OnMessage(Context context, Intent intent)
        {
            Log.Info(PushHandlerBroadcastReceiver.TAG, "GCM Message Received!");

            var msg = new StringBuilder();

            if (intent != null && intent.Extras != null)
            {
                foreach (var key in intent.Extras.KeySet())
                    msg.AppendLine(key + "=" + intent.Extras.Get(key).ToString());
            }

            //Store the message
            var prefs = GetSharedPreferences(context.PackageName, FileCreationMode.Private);
            var edit = prefs.Edit();
            edit.PutString("last_msg", msg.ToString());
            edit.Commit();


			var title = intent.Extras.GetString("title");

			var author = intent.Extras.GetString("author");

			var id = intent.Extras.GetString("id");

			if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author) && !string.IsNullOrEmpty(id))
			{
				//createNotification(title, author, Convert.ToInt32(id));
				createNotification(author,title,Convert.ToInt32(id));
				return;
			}
 

            string message = intent.Extras.GetString("message");
            if (!string.IsNullOrEmpty(message))
            {
                createNotification("En la cancha", message);
                return;
            }

            string msg2 = intent.Extras.GetString("msg");
            if (!string.IsNullOrEmpty(msg2))
            {
                createNotification("New hub message!", msg2);
                return;
            }

            createNotification("Unknown message details", msg.ToString());
        }

        protected override bool OnRecoverableError(Context context, string errorId)
        {
            Log.Warn(PushHandlerBroadcastReceiver.TAG, "Recoverable Error: " + errorId);

            return base.OnRecoverableError(context, errorId);
        }

        protected override void OnError(Context context, string errorId)
        {
            Log.Error(PushHandlerBroadcastReceiver.TAG, "GCM Error: " + errorId);
        }


		void createNotification(string title, string desc,int id=0)
		{
			// Pass the current button press count value to the next activity:
			Bundle valuesForActivity = new Bundle();
			valuesForActivity.PutInt("feedId", id);

			// When the user clicks the notification, SecondActivity will start up.
			Intent resultIntent = new Intent(this, typeof(MainActivity));

			// Pass some values to SecondActivity:
			resultIntent.PutExtras(valuesForActivity);

			// Construct a back stack for cross-task navigation:
			TaskStackBuilder stackBuilder = TaskStackBuilder.Create(this);
			stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(MainActivity)));
			stackBuilder.AddNextIntent(resultIntent);

			// Create the PendingIntent with the back stack:            
			PendingIntent resultPendingIntent =
				stackBuilder.GetPendingIntent(0, (int)PendingIntentFlags.UpdateCurrent);

			// vibration Pattern
			long[] pattern = {500,500,500,800,500};


			// Build the notification:
			NotificationCompat.Builder builder = new NotificationCompat.Builder(this)
				.SetAutoCancel(true)                    // Dismiss from the notif. area when clicked
				.SetContentIntent(resultPendingIntent)  // Start 2nd activity when the intent is clicked.
				.SetContentTitle(title)
				//.SetNumber(777)                       // Display the count in the Content Info
				//.SetLights( Color.BLUE, 500, 500)

				.SetVibrate(pattern)
				.SetSmallIcon(Resource.Drawable.ic_launcher)  // Display this icon
				.SetTicker(desc)
				.SetSound( GetNotificationSound(0)  )
				.SetStyle(new NotificationCompat.BigTextStyle().BigText(desc))
				.SetContentText(desc); // The message to display.


			// Finally, publish the notification:
			NotificationManager notificationManager =
				(NotificationManager)GetSystemService(Context.NotificationService);
			notificationManager.Notify(id, builder.Build());

			// Increment the button press count:

		}

		 
		private Android.Net.Uri GetNotificationSound(int categoryId)
		{
			//Android.Net.Uri sound = Android.Net.Uri.Parse ("android.resource://"+this.BaseContext.PackageName+"/"+Resource.Raw.oritaaviso);

			var defaultSound = Android.Media.RingtoneManager.GetDefaultUri (Android.Media.RingtoneType.Notification);

			//return sound;
			return defaultSound;
		}

        private NotificationHub Hub { get; set; }

    }
}