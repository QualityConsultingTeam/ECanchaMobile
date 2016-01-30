using EC.Infrastructure;
using EC.ServiceAgents;
using EC.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace EC.Forms.Views 
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FieldView : ContentPage
    {
        public FieldView()
        {
            InitializeComponent();
            // this.BindingContext = new FieldsViewModel(this);

            this.BindingContext = new FieldsViewModel(this);
            //listView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.GoToDetailsCommand.Execute(null);
        }

        private FieldsViewModel ViewModel
        {
            get { return this.BindingContext as FieldsViewModel; }
        }

        protected override   void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel.FieldsCollection.Any()) return;

             Task.Run(async ()=> await ViewModel.GetFieldsFromApiAsync());
        }

    }
}
