using Xamarin.Forms;

namespace EC.Forms.Views
{
    public  class AlertView   : StackLayout
    {
        public AlertView()
        {
			Device.OnPlatform (() => {
				Padding = new Thickness (0, 40, 0, 0);
			});

            this.BackgroundColor = Color.Gray;

            var label = new LabelRender();

            var loading = new ActivityIndicator(){ IsRunning = true};

            this.Children.Add(loading);

            label.Text = TextConstant.Wait;

            label.TextColor = Color.White;

            label.HorizontalOptions = LayoutOptions.CenterAndExpand;

            label.VerticalOptions = LayoutOptions.CenterAndExpand;

            this.HorizontalOptions = LayoutOptions.CenterAndExpand;

            this.Children.Add(label);

            this.WidthRequest = 200;

            this.HeightRequest = 80;
        }
    }
}
