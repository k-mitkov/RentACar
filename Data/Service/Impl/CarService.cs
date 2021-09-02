using Data.Enums;
using Data.Models;
using DesktopClient.Util;
using System;
using System.Collections.Generic;

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
        public IEnumerable<Car> GetCarsByPeriodAndType(Period period, TypeVehicle type)
        {
            try{
                return data.CarsByPeriodAndType(period, type);
            }
            catch(Exception ex)
            {
                ExceptionLogger.LoggException(ex);
                return null;
            }
        }

        public bool ReserveCar(Car car, Period period, Client client, Locations location)
        {
            try
            {
                return data.MakeReservation(car, period, client, location);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LoggException(ex);
                return false;
            }
        }
        #endregion
    }
}
