using EC.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EC.Forms.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        public LoginViewModel()
        {

        }


        #region Public Properties

        public string Email {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public string Password {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public Command LoginCommand {
            get
            {
                return _loginCommand ??
                    (_loginCommand = new Command(async () => await LoginAction(),
                    () => !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password)));
            }
        }

        private async Task LoginAction()
        {
            var result = await CoreClient.AccountService.Login(Email, Password, false);

            if (!string.IsNullOrEmpty(result.access_token)){
                await this.Navigation.PushAsync(new FieldView());
            }

        }
        #endregion

        #region Private Properties

        private string _email; //{ get; set; }
        private string _password; //{ get; set; }

        private Command _loginCommand;

        #endregion



    }
}//cierre de clase
