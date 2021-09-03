using Data.Enums;
using Data.Models;
using Data.Service;
using Data.Service.Impl;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService service = new DataService();
            ICarService carService = new CarService();

            //Language language = new Language()
            //{
            //    Lenguage = LenguageEnum.English,
            //    IconPath = @"\Resources\Images\flag-en.jpg"
            //};

            //Language language2 = new Language()
            //{
            //    Lenguage = LenguageEnum.Български,
            //    IconPath = @"\Resources\Images\flag-bg.jpg"
            //};

            //service.AddNewLenguage(language);
            //service.AddNewLenguage(language2);

            //var period = new Period()
            //{
            //    From = new DateTime(2021, 8, 25, 12, 0, 0),
            //    To = new DateTime(2021, 9, 1, 12, 0, 0),
            //    Location = Locations.Sofia
            //};

            //var client = new Client()
            //{
            //    Mail = "krasi0m0@gmail.com",
            //    FirstName = "Krasimir",
            //    LastName = "Mitkov",
            //    Phone = "0893458999",
            //    DateOfBirth = new DateTime(2000, 02, 27)
            //};

            //Console.WriteLine(client.FirstName);

            //carService.ReserveCar(service.GetCars().FirstOrDefault(), period, client, Locations.Sofia);

            //var period1 = new Period()
            //{
            //    From = DateTime.Now,
            //    To = DateTime.MaxValue,
            //    Location = Locations.Sofia
            //};

            //List<Period> periods = new List<Period>();

            //periods.Add(period1);

            //var car = new Car()
            //{
            //    Brand = "Audi",
            //    Model = "Q3",
            //    Capacity = 5,
            //    Consumation = 9m,
            //    Path = @"\Resources\Images\audi-q3.png",
            //    Price = 80,
            //    Type = TypeVehicle.Car,
            //    Year = 2018,
            //    Periods = periods
            //};

            //service.AddNewCar(car);

            //var period = new Period()
            //{
            //    From = new DateTime(2021, 8, 25, 12, 0, 0),
            //    To = new DateTime(2021, 9, 1, 12, 0, 0),
            //    Location = Locations.Sofia
            //};

            //Console.WriteLine(period.To - period.From);

            //IEnumerable<Car> cars = service.CarsByPeriod(period);

            //Car car = service.FindCar(cars.First().Id);
            //Period period1 = car.Periods.FirstOrDefault();
            //period1.Car = car;

            //service.DeletePeriod(period1);
            ////period1.To = period.From;

            //var period2 = new Period()
            //{
            //    From = period.To,
            //    To = DateTime.MaxValue,
            //    Location = Locations.Plovdiv
            //};

            //period.Location = Locations.OnTrip;

            ////IEnumerable<Car> cars2 = service.CarsByPeriod(period);

            ////Car car2 = service.FindCar(cars.First().Id);

            ////Period period3 = new Period()
            ////{
            ////    From = period1.From,
            ////    To = period1.To,
            ////    Location = period1.Location
            ////};

            ////period3.Car = car2;
            ////period.Car = car2;
            ////period2.Car = car2;

            ////car.Periods.Add(period1);
            ////car.Periods.Add(period1);
            ////car.Periods.Add(period1);

            ////service.UpdateCar(car);

            //service.AddNewPeriod(period1);
            ////service.AddNewPeriod(period);
            ////service.AddNewPeriod(period2);


        }
    }
}
