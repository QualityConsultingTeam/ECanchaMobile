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

        public LoginViewModel(Page page)
        {
			this._currentPage = page;
        }


        #region Public Properties

        public string Email {
            get { return _email; }
			set { _email = value;OnPropertyChange ("Email");}
        }

        public string Password {
            get { return _password; }
			set { _password = value; OnPropertyChange ("Password"); }
        }

        public Command LoginCommand {
            get
            {
				return _loginCommand ??
				(_loginCommand = new Command (async () => await LoginAction ()));
                   // () => !string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password)));
            }
        }

        private async Task LoginAction()
        {
			if (string.IsNullOrEmpty (Email) || string.IsNullOrEmpty (Password))
				return;
			await this._currentPage.Navigation.PushModalAsync (new LoadingView ());
            var result = await CoreClient.AccountService.Login(Email, Password, false);

            if (!string.IsNullOrEmpty(result.access_token)){
                
				await this._currentPage.Navigation.PopModalAsync ();

				await this._currentPage.Navigation.PopToRootAsync ();

				return;
            }

			await this._currentPage.DisplayAlert ("Inicio De Sesión", "Usuario o Contraseña inválidos", "Ok!");
			await this._currentPage.Navigation.PopModalAsync ();

        }
        #endregion

        #region Private Properties

        private string _email; //{ get; set; }
        private string _password; //{ get; set; }

        private Command _loginCommand;

        #endregion



    }
}//cierre de clase
