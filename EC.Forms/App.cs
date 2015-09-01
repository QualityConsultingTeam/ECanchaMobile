using EC.Forms.Views;

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
          
            MainPage = new NavigationPage(new FieldView())
            {
                BarBackgroundColor = Color.FromHex("cb1f24"),
                BarTextColor = Color.White,
                
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
