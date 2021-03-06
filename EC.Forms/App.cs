﻿using EC.Infrastructure;
using EC.ServiceAgents;
using EC.Forms.Infrastructure;
using EC.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace EC.Forms
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            //MainPage = new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                XAlign = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            //};
            
            MainPage = new MasterView();
            MainPage.Title = "En la Cancha";
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public IHUDProvider _hud;
        public static int AnimationSpeed = 250;

        //public static NotificationPayload PendingNotificationPayload
        //{
        //    get;
        //    private set;
        //}

        public IHUDProvider Hud
        {
            get
            {
                return _hud ?? (_hud = DependencyService.Get<IHUDProvider>());
            }
        }

        public new static App Current
        {
            get
            {
                return (App)Application.Current;
            }
        }

        public static Athlete CurrentAthlete
        {
            get
            {
                return Settings.Instance.AthleteId == null ? null : DataManager.Instance.Athletes.Get(Settings.Instance.AthleteId);
            }
        }

        public static bool IsNetworkRechable
        {
            get;
            set;
        }

        public static List<string> PraisePhrases
        {
            get;
            set;
        }

        public static List<string> AvailableLeagueColors
        {
            get;
            set;
        }

        public Dictionary<string, string> UsedLeagueColors
        {
            get;
            set;
        } = new Dictionary<string, string>();

        public static string AuthToken
        {
            get;
            set;
        }

        public static string AuthTokenAndType
        {
            get
            {
                return AuthToken == null ? null : "{0} {1}".Fmt("Bearer", AuthToken);
            }
        }
    }
}
