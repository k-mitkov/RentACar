using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopClient.ViewModels
{
    class SelectViewModel : BaseViewModel
    {
        #region Declarations
        IEnumerable<Car> cars;
        #endregion

        #region Constructor

        public SelectViewModel(IEnumerable<Car> cars)
        {
            this.cars = cars;
        }
        #endregion
    }
}
