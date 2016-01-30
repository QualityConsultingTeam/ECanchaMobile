using EC.DocumentResponse;
using EC.Forms.Views;
using EC.Infrastructure.Abstractions.Services;
using EC.ServiceAgents;
using EC.ServiceAgents.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace EC.Forms.ViewModels
{
    
    public class FieldsViewModel : ViewModelBase
    {

        public FieldsViewModel(Page page)
        {
			this._currentPage = page;
        }
         
    
        #region ListView Update News
    
     

        public bool IsBusyActivity
        {
            get { return _isBusyActivity; }
			set 
			{ 
				_isBusyActivity = value; 
				OnPropertyChange ("IsBusyActivity");
			}
        }

        public Command RefreshFieldsCommand
        {
            get
            {
                return _RefreshFieldsCommand ??
                    (_RefreshFieldsCommand = new Command(async () => await GetFieldsFromApiAsync(),
                    ()=> !IsBusy));
            }
        }
        
        public Command GoToDetailsCommand
        {
            get
            {
				return _goToDetailsCommand ??
				(_goToDetailsCommand = new Command (async() => await this._currentPage.Navigation.PushAsync (new WooferPage ())));
            }
        }

        #endregion

        
        #region ListView Data Source

        public ObservableCollection<Field> FieldsCollection
        {
            get { return _fields; }
            set
            {
				_fields = value;
				OnPropertyChange ("FieldsCollection");
            }
        }



        internal void FetchInBackground()
        {
			Task.Run(()=>GetFieldsFromApiAsync());

        }


        /// <summary>
        /// Load Data From web api
        /// </summary>
        /// <returns></returns>
        public async Task GetFieldsFromApiAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            //var location = await DependencyService.Get<ILocationServiceSingleton>()
            //    .CalculatePositionAsync();

            var filter = new FilterOptionModel() { date = DateTime.Now };

            var collection= await CoreClient.FieldsService.GetFields(filter);
			if(collection!=null && collection.Any()) FieldsCollection = new ObservableCollection<Field>(collection);
            IsBusy = false;
        }



        #endregion
        
        #region Private Fields

        private ObservableCollection<Field> _fields = new ObservableCollection<Field>();

        private Command _RefreshFieldsCommand = null;
        private Command _goToDetailsCommand = null;
        private bool isBusy;
        private bool _isBusyActivity;
        #endregion


    }
}
