using EC.Infrastructure;
using EC.Infrastructure.Abstractions.Repositories;
using EC.Infrastructure.Abstractions.Services;
using EC.ServiceAgents;
using EC.ServiceAgents.Interfaces;
using EC.Forms.Infrastructure;
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
    public class BaseTabbedViewModel : BaseViewModel
    {
        public BaseTabbedViewModel(Page currentPage) : base(currentPage)
        {
            Tab1Click();
            SetPdf();
            Tab1Command = new Command(Tab1Click);
            Tab2Command = new Command(Tab2Click);


            _dataRepository = new ApplicationDataRepository();
            
            _settings = new ApplicationSettingServiceSingleton(_dataRepository);
            _locationService = new LocationServiceSingleton(_settings);
            CoreClient = new CoreClient(_settings,new ApplicationStorageService(_dataRepository));
          

        }

        #region Public Properties

        public bool IsTab1Selected
        {
            get { return _isTab1Selected; }
            set
            {
                _isTab1Selected = value;
                OnPropertyChange();
            }
        }

        public bool IsTab2Selected
        {
            get { return _isTab2Selected; }
            set
            {
                _isTab2Selected = value;
                OnPropertyChange();
            }
        }

        public Color Tab1BackgroundColor
        {
            get { return _tab1BackgroundColor; }
            set
            {
                _tab1BackgroundColor = value;
                OnPropertyChange();
            }
        }

        public Color Tab2BackgroundColor
        {
            get { return _tab2BackgroundColor; }
            set
            {
                _tab2BackgroundColor = value;
                OnPropertyChange();
            }
        }

        public Color Tab1TextColor
        {
            get { return _tab1TextColor; }
            set
            {
                _tab1TextColor = value;
                OnPropertyChange();
            }
        }

        public Color Tab2TextColor
        {
            get { return _tab2TextColor; }
            set
            {
                _tab2TextColor = value;
                OnPropertyChange();
            }
        }

        public string PdfPath
        {
            get { return _pdfPath; }
            set
            {
                _pdfPath = value;
                OnPropertyChange();
            }
        }

        public ICommand Tab1Command { get; set; }
        public ICommand Tab2Command { get; set; }

        #endregion

        #region Public Methods

        public void SetPdf()
        {
            var webView = CurrentPage.FindByName<CustomWebView>("ECWebView");

            if (Device.OS == TargetPlatform.Android)
            {
                //if (CurrentPage.GetType() == typeof(InfoView))
                //    webView.Source = Constants.PdfDocInfo;
                //else if (CurrentPage.GetType() == typeof(CityGuideView))
                //    webView.Source = Constants.PdfDocCityGuide;
            }
            else
            {
                //if (CurrentPage.GetType() == typeof(InfoView))
                //    webView.PdfPath = Constants.PdfDocInfoLocal;
                //else if (CurrentPage.GetType() == typeof(CityGuideView))
                //    webView.PdfPath = Constants.PdfDocCityGuideLocal;
            }
        }

        #endregion

        #region Protected Methods

        protected void Tab1Click()
        {
            if (IsTab1Selected)
                return;

            SetNewsSelected(true);
        }

        protected void Tab2Click()
        {
            if (IsTab2Selected)
                return;

            SetNewsSelected(false);
        }

        #endregion

        #region Private Methods

        private void SetNewsSelected(bool newSelected)
        {
            Tab1BackgroundColor = newSelected ? Constants.RedColor : Constants.WhiteColor;
            Tab2BackgroundColor = !newSelected ? Constants.RedColor : Constants.WhiteColor;

            IsTab1Selected = newSelected;
            IsTab2Selected = !newSelected;

            Tab1TextColor = newSelected ? Constants.WhiteColor : Constants.GreyColor;
            Tab2TextColor = !newSelected ? Constants.WhiteColor : Constants.GreyColor;
        }

        #endregion

        #region Private Fields

        private string _pdfPath;
        private Color _tab1BackgroundColor, _tab2BackgroundColor, _tab1TextColor, _tab2TextColor;
        private bool _isTab1Selected, _isTab2Selected;


        protected ICoreClient CoreClient { get; private set; }
        private readonly ILocationServiceSingleton _locationService;
      

        public static IApplicationSettingServiceSingleton _settings { get; set; }
        
        public static IApplicationDataRepository _dataRepository { get; set; }

        

        #endregion
    }
}
