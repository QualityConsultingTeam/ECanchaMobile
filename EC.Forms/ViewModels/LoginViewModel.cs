using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Forms.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        #region Public Properties

        public string Email {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        public string Password {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        #endregion

        #region Private Properties

        private string _email; //{ get; set; }
        private string _password; //{ get; set; }

        #endregion



    }
}//cierre de clase
