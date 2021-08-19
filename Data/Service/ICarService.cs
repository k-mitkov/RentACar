using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service
{
    public interface ICarService
    {
        IEnumerable<Car> GetCarsByPeriod(Period period);

        bool ReserveCar(Car car, Period period, Client client, Locations location);
    }
}
