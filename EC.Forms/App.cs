﻿using EC.Client.Core.Infrastructure;
using EC.Client.Core.ServiceAgents;
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
          
            MainPage = new NavigationPage(new FieldsView())
            {
                //BarBackgroundColor = Color.FromHex("cb1f24"),
                //BarTextColor = Color.White,
                
            };

            MainPage.Title = "En la Cancha App";
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

      
    }
}
