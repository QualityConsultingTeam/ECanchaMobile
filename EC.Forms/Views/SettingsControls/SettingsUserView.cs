﻿using System;

using Xamarin.Forms;
using ImageCircle.Forms.Plugin.Abstractions;

namespace EC.Forms.Views
{
	public class SettingsUserView : ContentView
	{
		public SettingsUserView ()
		{
			Content = new StackLayout () {
				Padding = new Thickness(10,10,10,5),
				Spacing = 15,
				Orientation = StackOrientation.Horizontal,
				Children = {
					new CircleImage {
						BorderColor = AppStyle.BrandColor,
						BorderThickness = 2,
						HeightRequest = 50,
						WidthRequest = 50,
						Aspect = Aspect.AspectFill,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						Source = new UriImageSource { Uri = new Uri ("http://bit.ly/1s07h2W") },
					},
					new Label () { 
						Text = "Bryan Garet", 
						TextColor = Color.White,
						VerticalOptions = LayoutOptions.Center, },
				}
			};
		}
	}
}