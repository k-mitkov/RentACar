using Data.Enums;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data.Service.Impl
{
    public class DataService : IDataService
    {
        #region Declaration
        DataContext context;
        #endregion

        #region Methods
        public void AddNewCar(Car car)
        {
            using (context = new DataContext())
            {
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }

        public void AddNewClient(Client client)
        {
            using (context = new DataContext())
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
        }

        public void AddNewPeriod(Period period)
        {
            using (context = new DataContext())
            {
                var car = context.Cars.Include("Periods").First();
                period.Car = car;
                period.CarId = car.Id;
                car.Periods.Add(period);

                context.SaveChanges();
            }
        }

        public void AddNewReservations(Reservation reservation)
        {
            using (context = new DataContext())
            {
                context.Reservations.Add(reservation);
                context.SaveChanges();
            }
        }

        public void AddNewLenguage(Language language)
        {
            using (context = new DataContext())
            {
                context.Languages.Add(language);
                context.SaveChanges();
            }
        }

        public IEnumerable<Language> GetLanguages()
        {
            using (context = new DataContext())
            {
                return context.Languages.Select(l => l).AsQueryable().ToList();
            }
        }

        public IEnumerable<Car> CarsByPeriodAndType(Period period, TypeVehicle type)
        {
            using (context = new DataContext())
            {
                return context.Periods.Where((p) => p.From < period.From && p.To > period.To && p.Location == period.Location && p.Car.Type == type).Select((p) => p.Car).AsQueryable().ToList();
            }
        }

        public bool DeletePeriod(Period period)
        {
            using (context = new DataContext())
            {
                var car = context.Cars.Include("Periods").First();
                car.Periods.Remove(context.Periods.FirstOrDefault(p => p.From == period.From && p.To == period.To));
                context.SaveChanges();
                return true;
            }
        }

        public Period FindPeriod(Period period)
        {
            using (context = new DataContext())
            {
                return context.Periods.FirstOrDefault(p => p.From == period.From && p.To == period.To);
            }
        }

        public IEnumerable<Car> GetCars()
        {
            using (context = new DataContext())
            {
                return context.Cars.Include("Periods").Select(c=>c).AsQueryable().ToList();
            }
        }

        public Car FindCar(int id)
        {
            using (context = new DataContext())
            {
                return context.Cars.Include("Periods").FirstOrDefault(c=>c.Id == id);
            }
        }

        public Client FindClientByMail(string mail)
        {
            using (context = new DataContext())
            {
                return context.Clients.FirstOrDefault(c => c.Mail.Equals(mail));
            }
        }

        public void UpdateCar(Car car)
        {
            using (context = new DataContext()) using (var transaction = context.Database.BeginTransaction())
            {
                context.Cars.Update(car);
                context.SaveChanges();

                transaction.Commit();
            }
        }

        public bool MakeReservation(Car car, Period period, Client client, Locations location)
        {
            using (context = new DataContext()) using (var transaction = context.Database.BeginTransaction())
            {
                if (context.Clients.FirstOrDefault(c => c.Mail.Equals(client.Mail)) != null)
                {
                    client = context.Clients.FirstOrDefault(c => c.Mail.Equals(client.Mail));
                }
                else
                {
                    context.Clients.Add(client);
                }

                car = context.Cars.Include("Periods").FirstOrDefault(c => c.Id == car.Id);

                var oldPeriod = context.Periods.FirstOrDefault((p) => p.From < period.From && p.To > period.To && p.Location == period.Location && p.CarId == car.Id);

                period.Location = Locations.OnTrip;
                period.Car = car;
                period.CarId = car.Id;

                var prevPeriod = new Period()
                {
                    From = oldPeriod.From,
                    To = period.From,
                    Location = oldPeriod.Location
                };
                prevPeriod.Car = car;
                prevPeriod.CarId = car.Id;

                period.Location = Locations.OnTrip;
                period.Car = car;
                period.CarId = car.Id;

                var aftarPeriod = new Period
                {
                    From = period.To,
                    To = oldPeriod.To,
                    Location = location
                };
                aftarPeriod.Car = car;
                aftarPeriod.CarId = car.Id;

                car.Periods.Remove(oldPeriod);
                car.Periods.Add(prevPeriod);
                car.Periods.Add(period);
                car.Periods.Add(aftarPeriod);

                var reservation = new Reservation()
                {
                    Car = car,
                    Period = period,
                    Client = client
                };

                context.Reservations.Add(reservation);

                context.SaveChanges();

                transaction.Commit();
            }
            return true;
        }
        #endregion
    }
}
