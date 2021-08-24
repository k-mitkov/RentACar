using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service
{
    public interface IDataService
    {
        IEnumerable<Car> CarsByPeriodAndType(Period period, TypeVehicle type);
        void UpdateCar(Car car);
        void AddNewCar(Car car);
        void AddNewPeriod(Period period);
        void AddNewClient(Client client);
        void AddNewReservations(Reservation reservation);
        void AddNewLenguage(Language language);
        bool DeletePeriod(Period period);
        Client FindClientByMail(string mail);
        Car FindCar(int id);
        Period FindPeriod(Period period);
        IEnumerable<Car> GetCars();

        IEnumerable<Language> GetLanguages();

        bool MakeReservation(Car car, Period period, Client client, Locations location);

    }
}
