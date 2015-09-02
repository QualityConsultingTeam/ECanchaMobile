using EC.Forms.ViewModels;

using Xamarin.Forms;

namespace EC.Forms.Views
{
    public partial class FieldView : ContentPage
    {
        public FieldView()
        {
            InitializeComponent();
            // this.BindingContext = new FieldsViewModel(this);

            this.BindingContext = new FieldsViewModel(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((FieldsViewModel)this.BindingContext).LoadData();
        }

    }
}
