using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EC.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayTokenPage : ContentPage
    {

        public DisplayTokenPage()
        {
            InitializeComponent();
        }
        public DisplayTokenPage(string token)
        {
            InitializeComponent();
            this.Content = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        Text = token
                    }
                }
            };
        }
    }
}
