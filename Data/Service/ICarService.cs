using Data.Enums;
using Data.Models;
using System.Collections.Generic;

namespace Data.Service
{
    public interface ICarService
    {
        IEnumerable<Car> GetCarsByPeriodAndType(Period period, TypeVehicle type);

        bool ReserveCar(Car car, Period period, Client client, Locations location);

        bool AddNewCar(Car car, Locations location);
    }
}
