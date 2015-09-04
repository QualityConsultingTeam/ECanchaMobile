﻿using EC.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EC.Forms.Views
{
    public partial class FieldsView : ContentPage
    {
        public FieldsView()
        {
            InitializeComponent();
            this.BindingContext = new FieldsViewModel(this);
        }
    }
}