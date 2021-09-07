using Data.Enums;
using Data.Models;
using DesktopClient.BussinesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesktopClient.ViewModels
{
    public class ViewCarsViewModel : BaseViewModel
    {
        #region Declarations
        IEnumerable<CarPeriodRapper> rappers;
        private CarPeriodRapper car;
        public event Action<CarPeriodRapper> ViewEvent;
        #endregion

        #region Constructor
        public ViewCarsViewModel()
        {
            Period period = new Period()
            {
                To = DateTime.Now.AddDays(1),
                From = DateTime.Now
            };
            IEnumerable<Car> cars = carService.GetCars();
            List<CarPeriodRapper> rappers = new List<CarPeriodRapper>();
            foreach (Car car in cars)
            {
                rappers.Add(new CarPeriodRapper(car, period, Locations.OnTrip));
            }
            Cars = rappers;
        }
        #endregion

        #region Proparties
        public IEnumerable<CarPeriodRapper> Cars
        {
            get
            {
                return rappers;
            }
            set
            {
                rappers = value;
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
            ViewEvent?.Invoke(car);
        }
        #endregion
    }
}
