using EC.Forms.Infrastructure;
using EC.Infrastructure;
using EC.Infrastructure.Abstractions.Repositories;
using EC.Infrastructure.Abstractions.Services;
using EC.ServiceAgents;
using EC.ServiceAgents.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;


namespace EC.Forms.ViewModels
{
	public  class ViewModelBase: BaseNotify
    {

        public ViewModelBase()
        {
            _dataRepository = new ApplicationDataRepository();

            _settings = new ApplicationSettingServiceSingleton(_dataRepository);
            _locationService = new LocationServiceSingleton(_settings);
            CoreClient = new CoreClient(_settings, new ApplicationStorageService(_dataRepository));
        }

		public virtual bool IsBusy
		{
			get { return _isBusy; }
			set { _isBusy = value; OnPropertyChange("IsBusy"); }
		}

		private bool _isBusy { get; set; }

		#region INotifyPropertyChanged implementation
		public event PropertyChangedEventHandler PropertyChanged;
		#endregion

		protected Page _currentPage;

		public void OnPropertyChange([CallerMemberName] string propertyName=null){
			if (PropertyChanged != null)
				PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}




		#region Private Fields



		protected ICoreClient CoreClient { get; private set; }
		private readonly ILocationServiceSingleton _locationService;


		public static IApplicationSettingServiceSingleton _settings { get; set; }

		public static IApplicationDataRepository _dataRepository { get; set; }



		protected void SetObservableProperty<T>(
			ref T field, 
			T value,
			[CallerMemberName] string propertyName = "")
		{
			if (EqualityComparer<T>.Default.Equals(field, value)) return;
			field = value;
			OnPropertyChange(propertyName);
		}

		internal virtual Task Initialize (params object[] args)
		{
			return Task.FromResult (0);
		}
		#endregion
    }
}
