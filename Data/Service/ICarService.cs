using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service
{
    public interface ICarService
    {
        IEnumerable<Car> GetCars(Period period);

        bool ReserveCar(Car car, Period period, Client client);
    }
}
