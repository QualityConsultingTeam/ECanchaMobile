﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EC.Forms.Views
{
    public class MasterView : MasterDetailPage
    {
        public MasterView()
        {
            Title = "EN LA CANCHA";
            Master = new SettingsPage();

           Detail =new NavigationPage( new FieldView());
            
        }
    }

    public class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            Style = AppStyle.SettingsPageStyle;

            var pageTitle = new Frame()
            {
                Style = AppStyle.PageTitleLabelFrameStyle,
                Padding = new Thickness(0, Device.OnPlatform(15, 0, 0), 0, 10),
                Content = new Label
                {
                    Style = AppStyle.PageTitleLabelStyle,
                    Text = "Settings",
                }
            };

            var signoutButton = new Button()
            {
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                Text = "Sign Out",
                TextColor = AppStyle.DarkLabelColor,
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20),
                Children = {
                    pageTitle,
                    new BoxView() {
                        HeightRequest = 1,
                        BackgroundColor = AppStyle.DarkLabelColor,
                    },
                    new SettingsUserView(),
                    new SyncView (),
                    new SettingsSwitchView ("GPS"),
                    new SettingsSwitchView ("Jobs Alert"),
                    signoutButton,
                    new StatusBarView()
                }
            };
        }
    }
}