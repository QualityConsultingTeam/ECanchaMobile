using EC.Infrastructure;
using EC.ServiceAgents;
using EC.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EC.Forms.Views
{
    public partial class FieldView : ContentPage
    {
        public FieldView()
        {
            InitializeComponent();
            // this.BindingContext = new FieldsViewModel(this);

            this.BindingContext = new FieldsViewModel(this.Navigation);
        }


        private FieldsViewModel ViewModel
        {
            get { return this.BindingContext as FieldsViewModel; }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel.FieldsCollection.Any()) return;

            Task.Run(async () => await ViewModel.GetFieldsFromApiAsync());
        }

    }
}
