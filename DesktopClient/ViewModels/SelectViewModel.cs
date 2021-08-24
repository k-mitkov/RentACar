using Data.Models;
using DesktopClient.BussinesModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopClient.ViewModels
{
    class SelectViewModel : BaseViewModel
    {
        #region Declarations
        IEnumerable<CarPeriodRapper> cars;
        #endregion

        #region Constructor
        public SelectViewModel(IEnumerable<CarPeriodRapper> rappers)
        {
            Cars = rappers;
        }
        #endregion

        #region Proparties
        public IEnumerable<CarPeriodRapper> Cars
        {
            get
            {
                return cars;
            }
            set
            {
                cars = value;
                OnPropertyChanged(nameof(Cars));
            }
        }
        #endregion
    }
}
