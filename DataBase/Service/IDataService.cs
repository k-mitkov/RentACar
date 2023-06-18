using DataBase.Enums;
using DataBase.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataBase.Service
{
    public interface IDataService
    {
        Task<IEnumerable<Car>> CarsByPeriodAndType(Period period, VehicleType type);
        Task UpdateCar(Car car);
        Task<Car> AddNewCar(Car car);
        Task<Period> AddNewPeriod(Period period);
        Task<User> AddNewClient(User client);
        Task<User> AddNewAdmin(User admin);
        Task<Reservation> AddNewReservations(Reservation reservation);
        //void AddNewLenguage(Language language);
        Task DeletePeriod(Period period);
        Task<User> FindClientByMail(string mail);
        Task<User> FindAdminByUsernameAndPassword(string username,string password);
        Task<Car> FindCar(int id);
        Task<Period> FindPeriod(Period period);
        Task<IEnumerable<Car>> GetCars();

        //IEnumerable<Language> GetLanguages();

        Task<Reservation> MakeReservation(Car car, Period period, Client client, Location location);

    }
}
