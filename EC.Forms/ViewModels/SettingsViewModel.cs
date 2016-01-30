using EC.Forms.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using EC.Model;

namespace EC.Forms.ViewModels
{
	public class SettingsViewModel : ViewModelBase
    {

        public SettingsViewModel(Action<Page> navigateAsync)
        {
            this.navigateAsync = navigateAsync;
            InitializeMenuValues();
            
        }

     
        public ICommand NavigateTologinCommand
        {
            get
            {
                return _navigateTologin ??
                   (_navigateTologin = new Command( () =>  navigateAsync(new LoginView())));
            }
        }

        public void InitializeMenuValues()
        {
            MenuItems = new ObservableCollection<EC.Model.MenuItem>();

            MenuItems.Add(new EC.Model.MenuItem()
            {
                Id = 0,
                Title = "Mi Cuenta",
                TargetType = typeof(MyAccount),
                Icon = "ic_fullscreen_black.png",
            });

            MenuItems.Add(new EC.Model.MenuItem()
            {
                Id = 0,
                Title = "Canchas",
                TargetType = typeof(HomeTabs),
                Icon = "ic_fullscreen_black.png",
            });

            

        }

        public ObservableCollection<EC.Model.MenuItem> MenuItems { get; set; }

        #region Private Propeties 

        public ICommand _navigateTologin;
        
        private Action<Page> navigateAsync;
        #endregion

    }
}
