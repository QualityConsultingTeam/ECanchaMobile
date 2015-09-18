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
using XLabs.Forms.Mvvm;

namespace EC.Forms.ViewModels
{
    public  class ViewModelBase: ViewModel
    {

        public ViewModelBase()
        {
            _dataRepository = new ApplicationDataRepository();

            _settings = new ApplicationSettingServiceSingleton(_dataRepository);
            _locationService = new LocationServiceSingleton(_settings);
            CoreClient = new CoreClient(_settings, new ApplicationStorageService(_dataRepository));
        }

        #region Private Fields

        


        protected ICoreClient CoreClient { get; private set; }
        private readonly ILocationServiceSingleton _locationService;


        public static IApplicationSettingServiceSingleton _settings { get; set; }

        public static IApplicationDataRepository _dataRepository { get; set; }



        #endregion
    }
}
