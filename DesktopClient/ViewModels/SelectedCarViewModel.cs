using Data.Enums;
using DesktopClient.BussinesModels;
using DesktopClient.Commands;
using DesktopClient.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopClient.ViewModels
{
    class SelectedCarViewModel : BaseViewModel
    {
        #region Declaration
        private CarPeriodRapper car;
        public event Action BackEvent;
        public event Action<CarPeriodRapper> SelectEvent;
        private ButtonCommand backCommand;
        private ButtonCommand bookCommand;
        private string locationFromStr;
        private string locationToStr;
        #endregion

        #region Constructor
        public SelectedCarViewModel(CarPeriodRapper car)
        {
            this.car = car;
            TranslationSource.Instance.LanguageEvent += LanguageChangeHandler;
            locationFromStr = car.LocationFrom.LocationStr;
            locationToStr = car.LocationTo.LocationStr;
        }
        #endregion

        #region Proparties
        public string Brand
        {
            get
            {
                return car.Brand;
            }
        }
        public string Model
        {
            get
            {
                return car.Model;
            }
        }
        public int Capacity
        {
            get
            {
                return car.Capacity;
            }
        }
        public decimal Consumation
        {
            get
            {
                return car.Consumation;
            }
        }
        public int Year
        {
            get
            {
                return car.Year;
            }
        }
        public string Path
        {
            get
            {
                return car.Path;
            }
        }

        public string FromDate
        {
            get
            {
                return car.From.ToString("dd/MM/yyyy");
            }
        }

        public string FromHour
        {
            get
            {
                return car.From.Hour + ":00";
            }
        }

        public string ToDate
        {
            get
            {
                return car.To.ToString("dd/MM/yyyy");
            }
        }

        public string ToHour
        {
            get
            {
                return car.To.Hour + ":00";
            }
        }

        public string LocationFrom
        {
            get
            {
                return locationFromStr;
            }
            set
            {
                locationFromStr = car.LocationFrom.LocationStr;
                OnPropertyChanged(nameof(LocationFrom));
            }
        }
        public string LocationTo
        {
            get
            {
                return locationToStr;
            }
            set
            {
                locationToStr = car.LocationTo.LocationStr;
                OnPropertyChanged(nameof(LocationTo));
            }
        }
        public decimal TotalPrice
        {
            get
            {
                return car.TotalPrice;
            }
        }
        public int Days
        {
            get
            {
                return car.Days;
            }
        }

        public ButtonCommand BackCommand
        {
            get
            {
                if (backCommand == null)
                {
                    backCommand = new ButtonCommand(OnBackCommand, CanExecuteShow);
                }
                return backCommand;
            }
        }

        public ButtonCommand BookCommand
        {
            get
            {
                if (bookCommand == null)
                {
                    bookCommand = new ButtonCommand(OnSelect, CanExecuteShow);
                }
                return bookCommand;
            }
        }
        #endregion

        #region Methods
        private bool CanExecuteShow(object o)
        {
            return true;
        }

        private void OnBackCommand(Object o)
        {
            BackEvent.Invoke();
        }

        private void OnSelect(Object o)
        {
            SelectEvent.Invoke(car);
        }

        public void LanguageChangeHandler()
        {
            LocationFrom = locationFromStr;
            LocationTo = locationToStr;
        }
        #endregion
    }
}
