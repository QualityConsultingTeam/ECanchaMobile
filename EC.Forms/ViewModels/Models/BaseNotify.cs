﻿using EC.Forms.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EC.Forms.ViewModels
{
    public class BaseNotify : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseNotify()
        {
        }

        public virtual void Dispose()
        {
            ClearEvents();
        }

        internal bool SetPropertyChanged<T>(ref T currentValue, T newValue, [CallerMemberName] string propertyName = "")
        {
            return PropertyChanged.SetProperty(this, ref currentValue, newValue, propertyName);
        }

        internal void SetPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void ClearEvents()
        {
            //Super awesome trick to wipe attached event handlers - +1 Clancey
            if (PropertyChanged == null)
                return;

            var invocation = PropertyChanged.GetInvocationList();
            foreach (var p in invocation)
                PropertyChanged -= (PropertyChangedEventHandler)p;
        }
    }

    public interface IDirty
    {
        bool IsDirty
        {
            get;
            set;
        }
    }
}

namespace System.ComponentModel
{
    public static class BaseNotify
    {
        //Just adding some new funk.tionality to System.ComponentModel
        public static bool SetProperty<T>(this PropertyChangedEventHandler handler, object sender, ref T currentValue, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(currentValue, newValue))
                return false;

            currentValue = newValue;

            var dirty = sender as IDirty;

            if (dirty != null)
                dirty.IsDirty = true;

            if (handler == null)
                return true;

            handler.Invoke(sender, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}