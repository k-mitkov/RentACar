using DataBase.Enums;
using DataBase.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBase.Service
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetCarsByPeriodAndType(Period period, VehicleType type);

        Task<IEnumerable<Car>> GetCars();

        Task<Reservation> ReserveCar(Car car, Period period, Client client, Location location);

        Task<Car> AddNewCar(Car car, Location location);
    }
}
