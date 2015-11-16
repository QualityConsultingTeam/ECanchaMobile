using EC.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EC.Forms.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            LoginButton.Clicked += LoginButton_Clicked;
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            var vm = (LoginViewModel)BindingContext;
            vm.LoginCommand.Execute(null);
        }
    }
}
