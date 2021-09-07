using Data.Enums;
using Data.Models;
using System.Collections.Generic;

namespace Data.Service
{
    public interface IDataService
    {
        IEnumerable<Car> CarsByPeriodAndType(Period period, TypeVehicle type);
        void UpdateCar(Car car);
        void AddNewCar(Car car);
        void AddNewPeriod(Period period);
        void AddNewClient(Client client);
        void AddNewAdmin(Admin admin);
        void AddNewReservations(Reservation reservation);
        void AddNewLenguage(Language language);
        bool DeletePeriod(Period period);
        Client FindClientByMail(string mail);
        Admin FindAdminByUsernameAndPassword(string username,string password);
        Car FindCar(int id);
        Period FindPeriod(Period period);
        IEnumerable<Car> GetCars();

        IEnumerable<Language> GetLanguages();

        bool MakeReservation(Car car, Period period, Client client, Locations location);

    }
}
