using EC.Forms.ViewModels;
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
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel(this);
         //   LoginButton.Clicked += LoginButton_Clicked;
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            var vm = (LoginViewModel)BindingContext;
            vm.LoginCommand.Execute(null);
        }
    }
}
