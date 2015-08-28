using System;
using System.Windows.Input;
 
using Xamarin.Forms;

namespace EC.Views
{
    public class NavigationBarView : Grid
    {
        
        #region Bindable Properties
        
        //public static readonly BindableProperty InfoImageProperty =
        //    BindableProperty.Create((NavigationBarView navView) => navView.InfoImage, Constants.InfoImageSource);

        //public static readonly BindableProperty WorkshopsImageProperty =
        //    BindableProperty.Create((NavigationBarView navView) => navView.WorkshopsImage, Constants.WorkshopsImageSource);

        //public static readonly BindableProperty DocumentsImageProperty =
        //    BindableProperty.Create((NavigationBarView navView) => navView.DocumentsImage, Constants.DocumentsImageSource);

        //public static readonly BindableProperty MapImageProperty =
        //    BindableProperty.Create((NavigationBarView navView) => navView.MapImage, Constants.MapImageSource);

        //public static readonly BindableProperty CityGuideImageProperty =
        //    BindableProperty.Create((NavigationBarView navView) => navView.CityGuideImage, Constants.CityGuideImageSource);

        public static readonly BindableProperty InfoCommandProperty =
            BindableProperty.Create((NavigationBarView navView) => navView.InfoCommand, new Command(() => { }));

        public static readonly BindableProperty WorkshopsCommandProperty =
            BindableProperty.Create((NavigationBarView navView) => navView.WorkshopsCommand, new Command(() => { }));

        public static readonly BindableProperty DocumentsCommandProperty =
            BindableProperty.Create((NavigationBarView navView) => navView.DocumentsCommand, new Command(() => { }));

        public static readonly BindableProperty MapCommandProperty =
            BindableProperty.Create((NavigationBarView navView) => navView.MapCommand, new Command(() => { }));

        public static readonly BindableProperty CityGuideCommandProperty =
            BindableProperty.Create((NavigationBarView navView) => navView.CityGuideCommand, new Command(() => { }));
        
        #endregion
        

        #region Properties
        
        //public ImageSource InfoImage
        //{
        //    get { return (ImageSource) GetValue(InfoImageProperty); }
        //    set { SetValue(InfoImageProperty, value); }
        //}

        //public ImageSource WorkshopsImage
        //{
        //    get { return (ImageSource) GetValue(WorkshopsImageProperty); }
        //    set { SetValue(WorkshopsImageProperty, value); }
        //}

        //public ImageSource DocumentsImage
        //{
        //    get { return (ImageSource) GetValue(DocumentsImageProperty); }
        //    set { SetValue(DocumentsImageProperty, value); }
        //}

        //public ImageSource MapImage
        //{
        //    get { return (ImageSource) GetValue(MapImageProperty); }
        //    set { SetValue(MapImageProperty, value); }
        //}

        //public ImageSource CityGuideImage
        //{
        //    get { return (ImageSource) GetValue(CityGuideImageProperty); }
        //    set { SetValue(CityGuideImageProperty, value); }
        //}

        public ICommand InfoCommand
        {
            get { return (ICommand) GetValue(InfoCommandProperty); }
            set { SetValue(InfoCommandProperty, value); }
        }

        public ICommand WorkshopsCommand
        {
            get { return (ICommand) GetValue(WorkshopsCommandProperty); }
            set { SetValue(WorkshopsCommandProperty, value); }
        }

        public ICommand DocumentsCommand
        {
            get { return (ICommand) GetValue(DocumentsCommandProperty); }
            set { SetValue(DocumentsCommandProperty, value); }
        }

        public ICommand MapCommand
        {
            get { return (ICommand) GetValue(MapCommandProperty); }
            set { SetValue(MapCommandProperty, value); }
        }

        public ICommand CityGuideCommand
        {
            get { return (ICommand) GetValue(CityGuideCommandProperty); }
            set { SetValue(CityGuideCommandProperty, value); }
        }
       
        #endregion

        public NavigationBarView()
        {
            Initialize();
            AddItems();
        }

        private void Initialize()
        {
            BackgroundColor = Constants.NavigationBarBackgroundColor;

            ColumnDefinitions = new ColumnDefinitionCollection
            {
                new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
            };

            RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition {Height = 2},
                new RowDefinition {Height = GridLength.Auto}
            };

            Padding = new Thickness(0, 0, 0, 10);
        }

        private void AddItems()
        {
            //Separator
            //Left, right, top, bottom -> 
            //bottom is used for calculate rowspan (bottom - top) 
            //right is used for calculate colspan (right - left) 
            Children.Add(new StackLayout {BackgroundColor = Constants.BorderColor}, 0, 5, 0, 1);

            Children.Add(CreateImageButton("InfoImage", "InfoCommand"), 0, 1);
            Children.Add(CreateImageButton("WorkshopsImage", "WorkshopsCommand"), 1, 1);
            Children.Add(CreateImageButton("DocumentsImage", "DocumentsCommand"), 2, 1);
            Children.Add(CreateImageButton("MapImage", "MapCommand"), 3, 1);
            Children.Add(CreateImageButton("CityGuideImage", "CityGuideCommand"), 4, 1);
        }

        /// <summary>
        /// Create instance of centered "ImageButton"
        /// </summary>
        /// <param name="imageSource"></param>
        /// <param name="commandPropertyName"></param>
        /// <returns></returns>
        private Image CreateImageButton(string imageSource, string commandPropertyName)
        {
            var newImage = new Image {HorizontalOptions = LayoutOptions.Center, HeightRequest = 35};

            newImage.SetBinding(Image.SourceProperty, imageSource);

            var gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, new Binding(commandPropertyName));

            newImage.GestureRecognizers.Add(gestureRecognizer);

            return newImage;
        }

    }
}
