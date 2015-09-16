using EC.DocumentResponse;
using EC.Infrastructure.Abstractions.Services;
using EC.ServiceAgents.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EC.Forms.ViewModels
{
    
    public class FieldsViewModel : BaseTabbedViewModel
    {

        public FieldsViewModel(Page currentPage)
            : base(currentPage)
        {
            FetchInBackground();
        }
         
    
        #region ListView Update News
    
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChange();
            }
        }


        public Command RefreshFieldsCommand
        {
            get
            {
                return _RefreshFieldsCommand ??
                    (_RefreshFieldsCommand =
                    new Command(async () => await GetFieldsFromApiAsync(),
                    () => { return !IsBusy; }));
            }
        }

      



      
        private bool isBusy;

        #endregion


        #region ListView Data Source

        public List<Field> FieldsCollection
        {
            get { return _fields; }
            set
            {
                _fields = value;
                OnPropertyChange();
            }
        }



        internal void FetchInBackground()
        {
            Task.Run (GetFieldsFromApiAsync);

        }


        /// <summary>
        /// Load Data From web api
        /// </summary>
        /// <returns></returns>
        private async Task GetFieldsFromApiAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            //var location = await DependencyService.Get<ILocationServiceSingleton>()
            //    .CalculatePositionAsync();

            var filter = new FilterOptionModel() { date = DateTime.Now };

            FieldsCollection = await CoreClient.FieldsService.GetFields(filter);
            IsBusy = false;
        }



        #endregion


        #region Private Fields

        private List<Field> _fields = new List<Field>();

        private Command _RefreshFieldsCommand = null;

        #endregion


    }
}
