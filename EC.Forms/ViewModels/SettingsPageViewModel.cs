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


namespace EC.Forms
{
	public  class SettingsPageViewModel : EC.Forms.ViewModels.ViewModelBase
	{
		public ObservableCollection<EC.Model.MenuItem> MenuItems { get; set; }

		public SettingsPageViewModel()
		{

			MenuItems = new ObservableCollection<EC.Model.MenuItem>();

			MenuItems.Add(new EC.Model.MenuItem()
				{
					Id=0,
					Title="Reserva tu Cancha",
					TargetType = typeof(HomeTabs),
					//Icon="publicamenu.png",
				});

			MenuItems.Add(new EC.Model.MenuItem()
				{
					Id = 1,
					Title = "Buscar Cancha",
					TargetType = typeof(HomeTabs),
					Icon = "ic_location_searching_white_24dp.png",
				});
 
			MenuItems.Add(new EC.Model.MenuItem()
				{
					Id = 2,
					Title = "Mi Cuenta",
					TargetType = typeof(LoginView),
					Icon = "ic_account_circle_white_24dp.png",
				});
			
		}


	}
}

