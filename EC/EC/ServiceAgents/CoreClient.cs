//using EC.Infrastructure.Abstractions.Services;
//using EC.Messages;
using EC.Infrastructure.Abstractions.Services;
using EC.ServiceAgents.Interfaces;
using System;

namespace EC.ServiceAgents
{
    public class CoreClient : ICoreClient
    {
        private readonly IApplicationSettingServiceSingleton _applicationSettingService;
          private readonly IApplicationStorageService _applicationStorageService;
        //private readonly IMvxMessenger _messenger;
        //private readonly MvxSubscriptionToken _token;

        IFieldsService _fieldService;
        IAccountService _accountService;

        public IFieldsService FieldsService
        {
            get
            {
                return _fieldService ?? 
                    (_fieldService = StartService() );
                     
            }
        }

        public IAccountService AccountService
        {
            get
            {
                return _accountService ??
                    (_accountService = new AccountService(_applicationSettingService.UrlPrefix, _applicationStorageService.SecurityToken));

            }
        }

        private FieldsService StartService()
        {
            return new FieldsService(_applicationSettingService.UrlPrefix, _applicationStorageService.SecurityToken);
        }

        public CoreClient(
            IApplicationSettingServiceSingleton applicationSettingService,
            IApplicationStorageService applicationStorageService)
            //IMvxMessenger messenger)
        {
            if (applicationSettingService == null)
            {
                throw new ArgumentNullException("applicationSettingService");
            }

            if (applicationStorageService == null)
            {
                throw new ArgumentNullException("applicationStorageService");
            }

            //if (messenger == null)
            //{
            //    throw new ArgumentNullException("messenger");
            //}

            _applicationSettingService = applicationSettingService;
            _applicationStorageService = applicationStorageService;
            //_messenger = messenger;

            //_token = _messenger.Subscribe<ReloadDataMessage>(_ => Refresh());
        }

      

        // NOTE: In order to notify "child" _*Service on UrlPrefix
        // change, make 2 things:
        // 1) Add IUpdatableUrlPrefix to its base interface, and
        // 2) Add 'if' below code for such service
        public void Refresh()
        {
            _applicationSettingService.Refresh();
            _applicationStorageService.Refresh();

            this.UpdateUrlPrefix(_fieldService);

        }

        private void UpdateUrlPrefix(IUpdatableUrl service)
        {
            if (service != null)
            {
                service.UrlPrefix = _applicationSettingService.UrlPrefix;
            }
        }

        void ICoreClient.Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
