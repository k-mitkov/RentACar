﻿using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Service
{
    public interface IDataService
    {
        IEnumerable<Car> CarsByPeriod(Period period);
        void UpdateCar(Car car);
        void AddNewCar(Car car);
        void AddNewPeriod(Period period);
        void AddNewClient(Client client);
        void AddNewReservations(Reservation reservation);
        bool DeletePeriod(Period period);
        Client FindClientByMail(string mail);
        Car FindCar(int id);
        Period FindPeriod(Period period);
        IEnumerable<Car> GetCars();

        bool MakeReservation(Car car, Period period, Client client, Locations location);

    }
}
