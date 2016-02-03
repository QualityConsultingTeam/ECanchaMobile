using EC.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using EC.Model;

namespace EC.Forms.Views
{
    public class MasterView : MasterDetailPage
    {
        public MasterView()
        {
            Title = "EN LA CANCHA";
            

			Detail = new NavigationPage (new HomeTabs());

            Master = new SettingsPage(navigateto);

        }

        public async void navigateto(EC.Model.MenuItem menu)
        {
            if (menu == null)
                return;

            Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);

            if(menu.TargetType== typeof(HomeTabs)) Detail = new NavigationPage(displayPage);

            else await Detail.Navigation.PushAsync(displayPage);

            IsPresented = false;
        }

        public async void NavigateAsync(Page page)
        {
            await Detail.Navigation.PushAsync(page);
            IsPresented = false;
        }
    }

 
	public class SettingsPage : ContentPage
	{

		private SettingsPageViewModel viewModel;

      

		public SettingsPage(Action<EC.Model.MenuItem> navigate  )
		{
             

            BindingContext = viewModel = new SettingsPageViewModel();
			Style = AppStyle.SettingsPageStyle;
			var pageTitle = new ContentView()
			{
				Style = AppStyle.PageTitleLabelFrameStyle,
				Padding = new Thickness(10, Device.OnPlatform(15,20, 0),0, 10),
				Content = new Label
				{
					Style = AppStyle.PageTitleLabelStyle,
					Text = "En la Cancha",
				},
				BackgroundColor = Color.FromHex(Constants.PrimaryColor),

			};


			var signoutButton = new Button()
			{
				VerticalOptions = LayoutOptions.EndAndExpand,
				HorizontalOptions = LayoutOptions.Center,
				Text = "Salir",
				TextColor = AppStyle.DarkLabelColor, 
			};

			var menu = new MenuView(navigate);


			var container = new StackLayout
			{
				Style = AppStyle.DefaultStack,
				Padding = new Thickness(0),
				Children = {
					pageTitle,
					//new BoxView() {
					//	HeightRequest = 5,
					//	BackgroundColor = Color.Black,

					//},
					new StackLayout()
					{
						Style= AppStyle.DefaultStack,
						BackgroundColor = Color.Transparent,
						Padding =  new Thickness(5),
						Children=
						{
							new SettingsUserView(),
							//new SyncView (),
							//new SettingsSwitchView ("GPS"),
							//new SettingsSwitchView ("Notificaciones"),

						}
					},
					new StackLayout()
					{
						Style = AppStyle.DefaultStack,
						BackgroundColor = Color.Transparent,

                        Children =
						{
							menu,

							 
						}
						},
					signoutButton,
					new StatusBarView()


				}
			};


			Content = new ScrollView()
			{
				Content = container
			};
			
		}



	}
}
