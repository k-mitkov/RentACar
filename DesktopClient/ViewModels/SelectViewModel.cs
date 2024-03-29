﻿using DesktopClient.BussinesModels;
using System;
using System.Collections.Generic;

namespace DesktopClient.ViewModels
{
    class SelectViewModel : BaseViewModel
    {
        #region Declarations
        IEnumerable<CarPeriodRapper> cars;
        private CarPeriodRapper car;
        public event Action<CarPeriodRapper> selectEvent;
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

        public CarPeriodRapper SelectedCar
        {
            get
            {
                return car;
            }
            set
            {
                car = value;
                if (car != null)
                {
                    OnSelect(car);
                }
            }
        }
        #endregion

        #region Methods
        private void OnSelect(CarPeriodRapper car)
        {
            selectEvent.Invoke(car);
        }
        #endregion
    }
}
