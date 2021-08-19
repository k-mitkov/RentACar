using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service.Impl
{
    public class CarService : ICarService
    {
        #region Declaration
        private IDataService data;
        #endregion

        #region Constructor
        public CarService()
        {
            data = new DataService();
        }
        #endregion

        #region Methods
        public IEnumerable<Car> GetCarsByPeriod(Period period)
        {
            return data.CarsByPeriod(period);
        }

        public bool ReserveCar(Car car, Period period, Client client, Locations location)
        {
            return data.MakeReservation(car, period, client, location);
        }
        #endregion
    }
}
