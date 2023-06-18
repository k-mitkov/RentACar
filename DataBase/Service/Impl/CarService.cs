using DataBase.Enums;
using DataBase.Models;
using DesktopClient.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBase.Service.Impl
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

        public async Task<Car> AddNewCar(Car car, Location location)
        {
            try
            {
                var period1 = new Period()
                {
                    From = DateTime.Now,
                    To = DateTime.MaxValue,
                    Location = location
                };

                List<Period> periods = new List<Period>();
                periods.Add(period1);
                car.Periods = periods;
                return await data.AddNewCar(car);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LoggException(ex);
                return null;
            }
        }

        public async Task<IEnumerable<Car>> GetCarsByPeriodAndType(Period period, VehicleType type)
        {
            try{
                return await data.CarsByPeriodAndType(period, type);
            }
            catch(Exception ex)
            {
                ExceptionLogger.LoggException(ex);
                return null;
            }
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            try
            {
                return await data.GetCars();
            }
            catch (Exception ex)
            {
                ExceptionLogger.LoggException(ex);
                return null;
            }
        }

        public async Task<Reservation> ReserveCar(Car car, Period period, Client client, Location location)
        {
            try
            {
                return await data.MakeReservation(car, period, client, location);
            }
            catch (Exception ex)
            {
                ExceptionLogger.LoggException(ex);
                return null;
            }
        }

        #endregion
    }
}
