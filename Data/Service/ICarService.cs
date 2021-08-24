using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service
{
    public interface ICarService
    {
        IEnumerable<Car> GetCarsByPeriodAndType(Period period, TypeVehicle type);

        bool ReserveCar(Car car, Period period, Client client, Locations location);
    }
}
