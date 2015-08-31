using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EC.Forms.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public bool IsBusyIOS
        {
            get
            {
                return isBusyIOS;
            }

            set
            {
                isBusyIOS = value;

                OnPropertyChange();
            }
        }

        private bool isBusyIOS;

        public BaseViewModel(Page currentPage)
        {
            this._currenPage = currentPage;

            NavigationPage.SetHasNavigationBar(currentPage, false);

            SetNavigationBarDefault();
            SetNavigationBarSelectedItem();
            SetNavigationBarCommands(); 
        }

      

        #region protected Methods

        protected async Task Navigate(Page page)
        {
            if (page.GetType() == this.GetType()) return;

            //TODO->Manage Clean stack
            if (CurrentPage.Navigation.NavigationStack.Count > 1)
            {
                var position = CurrentPage.Navigation.NavigationStack.AsEnumerable().Last().GetType() == page.GetType();

                if (position) return;
            }

            await this.CurrentPage.Navigation.PushAsync(page);

        }


        protected async Task BackNavigate()
        {
            await this.CurrentPage.Navigation.PopAsync(true);
        }

        protected void ShowAlert(string titleMessage, string message, string buttonText)
        {
            CurrentPage.DisplayAlert(titleMessage, message, buttonText);
        }


        /// <summary>
        /// Verificar Acceso a internet
        /// </summary>
        /// <returns></returns>
        protected bool CheckInternetAcces()
        {
            //var device = XLabs.Ioc.Resolver.Resolve<XLabs.Platform.Device.IDevice>();

            //var status = device.Network.InternetConnectionStatus();

            //return (status != XLabs.Platform.Services.NetworkStatus.NotReachable);
            return true;
        }

        #endregion

        #region Public Properties

        protected Page CurrentPage
        {
            get
            {
                return _currenPage;
            }
        }

        #region NavigationProperties

        public ImageSource InfoImage
        {
            get { return _infoImage; }
            set
            {
                _infoImage = value;
                OnPropertyChange();
            }
        }

        public ImageSource WorkshopsImage
        {
            get { return _workshopsImage; }
            set
            {
                _workshopsImage = value;
                OnPropertyChange();
            }
        }

        public ImageSource DocumentsImage
        {
            get { return _documentsImage; }
            set
            {
                _documentsImage = value;
                OnPropertyChange();
            }
        }

        public ImageSource MapImage
        {
            get { return _mapImage; }
            set
            {
                _mapImage = value;
                OnPropertyChange();
            }
        }

        public ImageSource CityGuideImage
        {
            get { return _cityGuideImage; }
            set
            {
                _cityGuideImage = value;
                OnPropertyChange();
            }
        }

        public ICommand InfoCommand { get; set; }
        public ICommand WorkshopsCommand { get; set; }
        public ICommand DocumentsCommand { get; set; }
        public ICommand MapCommand { get; set; }
        public ICommand CityGuideCommand { get; set; }

        #endregion

        #endregion

        #region Private Methods

        private void SetNavigationBarDefault()
        {
            //InfoImage = Constants.InfoImageSource;
            //WorkshopsImage = Constants.WorkshopsImageSource;
            //DocumentsImage = Constants.DocumentsImageSource;
            //MapImage = Constants.MapImageSource;
            //CityGuideImage = Constants.CityGuideImageSource;
        }

        private void SetNavigationBarSelectedItem()
        {
            //if (CurrentPage.GetType() == typeof(InfoView))
            //{
            //    InfoImage = Constants.SelectedInfoImageSource;
            //}
            //else if (CurrentPage.GetType() == typeof(WorkShops))
            //{
            //    WorkshopsImage = Constants.SelectedWorkshopsImageSource;
            //}
            //else if (CurrentPage.GetType() == typeof(DocumentsView))
            //{
            //    DocumentsImage = Constants.SelectedDocumentsImageSource;
            //}
            //else if (CurrentPage.GetType() == typeof(MapView))
            //{
            //    MapImage = Constants.SelectedMapImageSource;
            //}
            //else if (CurrentPage.GetType() == typeof(CityGuideView))
            //{
            //    CityGuideImage = Constants.SelectedCityGuideImageSource;
            //}
        }

        private void SetNavigationBarCommands()
        {
            //InfoCommand = new Command(NavigateToView<InfoView>);
            //WorkshopsCommand = new Command(NavigateToView<WorkShops>);
            //DocumentsCommand = new Command(NavigateToView<DocumentsView>);
            //MapCommand = new Command(NavigateToView<MapView>);
            //CityGuideCommand = new Command(NavigateToView<CityGuideView>);
        }

        private void NavigateToView<T>() where T : Page, new()
        {
            if (CurrentPage.GetType() != typeof(T) && !_isNavigating)
            {
                _isNavigating = true;
                Navigate(new T());
            }
        }

        #endregion

        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;


        public virtual void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Private Fields

        private Page _currenPage;
        private ImageSource _infoImage, _workshopsImage, _documentsImage, _mapImage, _cityGuideImage;
        /// <summary>
        /// Contains the value if is already navigating to a view
        /// </summary>
        private bool _isNavigating;

        #endregion

    }
}