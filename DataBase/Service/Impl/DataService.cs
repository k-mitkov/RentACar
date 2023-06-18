using DataBase.DataContext;
using DataBase.Enums;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataBase.Service.Impl
{
    public class DataService : IDataService
    {
        #region Declaration
        Context context;
        #endregion

        #region Methods
        public async Task<Car> AddNewCar(Car car)
        {
            using (context = new Context())
            {
                await context.Cars.AddAsync(car);
                await context.SaveChangesAsync();

                return car;
            }
        }

        public async Task<User> AddNewClient(User client)
        {
            using (context = new Context())
            {
                await context.Users.AddAsync(client);
                await context.SaveChangesAsync();

                return client;
            }
        }

        public async Task<User> AddNewAdmin(User admin)
        {
            using (context = new Context())
            {
                await context.Users.AddAsync(admin);
                await context.SaveChangesAsync();
            }

            return admin;
        }

        public async Task<Period> AddNewPeriod(Period period)
        {
            using (context = new Context())
            {
                var car = await context.Cars.Include("Periods").FirstAsync();
                period.Car = car;
                period.CarId = car.Id;
                car.Periods.Add(period);

                await context.SaveChangesAsync();

                return period;
            }
        }

        public async Task<Reservation> AddNewReservations(Reservation reservation)
        {
            using (context = new Context())
            {
                await context.Reservations.AddAsync(reservation);
                await context.SaveChangesAsync();

                return reservation;
            }
        }

        //public void AddNewLenguage(Language language)
        //{
        //    using (context = new DataContext())
        //    {
        //        context.Languages.Add(language);
        //        context.SaveChanges();
        //    }
        //}

        //public IEnumerable<Language> GetLanguages()
        //{
        //    using (context = new DataContext())
        //    {
        //        return context.Languages.Select(l => l).AsQueryable().ToList();
        //    }
        //}

        public async Task<IEnumerable<Car>> CarsByPeriodAndType(Period period, VehicleType type)
        {
            using (context = new Context())
            {
                return await context.Periods.Where((p) => p.From < period.From && p.To > period.To && p.Location.Id == period.Location.Id && p.Car.Type == type).Select((p) => p.Car).ToListAsync();
            }
        }

        public async Task DeletePeriod(Period period)
        {
            using (context = new Context())
            {
                var car = await context.Cars.Include("Periods").FirstAsync();
                car.Periods.Remove(context.Periods.FirstOrDefault(p => p.From == period.From && p.To == period.To));
                await context.SaveChangesAsync();
            }
        }

        public async Task<Period> FindPeriod(Period period)
        {
            using (context = new Context())
            {
                return await context.Periods.FirstOrDefaultAsync(p => p.From == period.From && p.To == period.To);
            }
        }

        public async Task<IEnumerable<Car>> GetCars()
        {
            using (context = new Context())
            {
                return await context.Cars.Include("Periods").Select(c=>c).ToListAsync();
            }
        }

        public async Task<Car> FindCar(int id)
        {
            using (context = new Context())
            {
                return await context.Cars.Include("Periods").FirstOrDefaultAsync(c=>c.Id == id);
            }
        }

        public async Task<User> FindClientByMail(string mail)
        {
            using (context = new Context())
            {
                return await context.Users.FirstOrDefaultAsync(c => c.Email.Equals(mail));
            }
        }

        public async Task<User> FindAdminByUsernameAndPassword(string username, string password)
        {
            using (context = new Context())
            {
                return await context.Users.FirstOrDefaultAsync(a => a.UserName.Equals(username) && a.PasswordHash.Equals(password));
            }
        }

        public async Task UpdateCar(Car car)
        {
            using (context = new Context()) using (var transaction = await context.Database.BeginTransactionAsync())
            {
                context.Cars.Update(car);
                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
        }

        public async Task<Reservation> MakeReservation(Car car, Period period, Client client, Location location)
        {
            using (context = new Context()) using (var transaction = await context.Database.BeginTransactionAsync())
            {
                if (await context.Clients.FirstOrDefaultAsync(c => c.Email.Equals(client.Email)) != null)
                {
                    client = await context.Clients.FirstOrDefaultAsync(c => c.Email.Equals(client.Email));
                }
                else
                {
                    await context.Clients.AddAsync(client);
                }

                car = await context.Cars.Include("Periods").FirstOrDefaultAsync(c => c.Id == car.Id);

                var oldPeriod = await context.Periods.FirstOrDefaultAsync((p) => p.From < period.From && p.To > period.To && p.Location == period.Location && p.CarId == car.Id);

                period.Location = new Location() { Id = 1, Name = "OnTrip" };
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

                await context.Reservations.AddAsync(reservation);

                await context.SaveChangesAsync();

                await transaction.CommitAsync();

                return reservation;
            }
        }
        #endregion
    }
}
