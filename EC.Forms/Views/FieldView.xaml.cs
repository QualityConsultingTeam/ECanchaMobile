using EC.Client.Core.Infrastructure;
using EC.Client.Core.ServiceAgents;
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

            this.BindingContext = new FieldsViewModel(this);
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    ((FieldsViewModel)this.BindingContext).LoadData();
        //}

    }
}
