using Data.Models;
using DesktopClient.BussinesModels;
using DesktopClient.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesktopClient.ViewModels
{
    public class CarViewModel : BaseViewModel
    {
        #region Declaration
        private CarPeriodRapper car;
        #endregion

        #region Constructor
        public CarViewModel(CarPeriodRapper car)
        {
            this.car = car;
        }

        #endregion

        #region Proparties
        
        public CarPeriodRapper Car
        {
            get
            {
                return car;
            }
            set
            {
                car = value;
                OnPropertyChanged(nameof(Car));
            }
        }

        public IEnumerable<Period> Periods => car.GetCar().Periods.OrderBy(p=>p.From);
        #endregion

        #region Methods

        #endregion
    }
}
