using Data.Service;
using Data.Service.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DesktopClient.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Declarations
        protected ICarService carService = new CarService();
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
