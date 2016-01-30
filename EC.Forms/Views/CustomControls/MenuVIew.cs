using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EC.Forms.Views
{
    public class MenuView : ContentView
    {
        private Action<EC.Model.MenuItem> NavigateAction;
        

        public ListView Menu { get; set; }


        public MenuView()
        {

            SetUpComponents();
        }

        public MenuView(Action<EC.Model.MenuItem> navigateAction)
        {
            this.NavigateAction = navigateAction;
            SetUpComponents();
        }


        public void Navigate(object o, SelectedItemChangedEventArgs e)
        {
            if (NavigateAction != null)
            {
                NavigateAction(e.SelectedItem as EC.Model.MenuItem);
            }
            Menu.SelectedItem = null;
        }


        private void SetUpComponents()
        {

             
            Menu = new CustomMenuList();
            Menu.SetBinding(ListView.ItemsSourceProperty, "MenuItems");
            Menu.ItemSelected += Navigate;

            Content = new StackLayout
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                Children =
                {
                   
                    Menu
                }
            };
        }




    }


    
	/// <summary>
	///  Custom    menu
	/// </summary>
	public class CustomMenuList : ListView
	{

		public CustomMenuList()
		{

			VerticalOptions = LayoutOptions.FillAndExpand;
			BackgroundColor = Color.White;
			SeparatorVisibility = SeparatorVisibility.None;





			ItemTemplate = new DataTemplate(() =>
				{
					BackgroundColor = Color.Transparent;
					var _Label = new Label() 
					{ 
						FontSize = 16, TextColor = AppStyle.DarkLabelColor ,
						FontAttributes = FontAttributes.None,HorizontalOptions= LayoutOptions.Center
					};
					_Label.SetBinding(Label.TextProperty, "Title");

					RowHeight = 50;

					var _Img = new Image() { WidthRequest =30, HeightRequest = 30};
					_Img.SetBinding(Image.SourceProperty, "Icon");

					return new ViewCell                                       
					{
						View = new StackLayout
						{
							Orientation = StackOrientation.Horizontal,
							Padding = new Thickness(18,0,0,0),
							Children =
							{
								_Img,
								new StackLayout
								{
									Padding = new Thickness(15,0,0,0)   ,
									VerticalOptions = LayoutOptions.Center,
									Spacing =0,
									Children =
									{
										_Label,
									}
									}
							}
							}
					};

				});
		}
	}
}
