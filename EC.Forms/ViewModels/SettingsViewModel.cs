using EC.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EC.Forms.ViewModels
{
    public class SettingsViewModel                 :ViewModelBase
    {

        public ICommand NavigateTologinCommand
        {
            get
            {
                return _navigateTologin ??
                   (_navigateTologin = new Command(async () => await Navigation.PushAsync(new LoginView())));
            }
        }



        #region Private Propeties 

        public ICommand _navigateTologin;
        #endregion 

    }
}
