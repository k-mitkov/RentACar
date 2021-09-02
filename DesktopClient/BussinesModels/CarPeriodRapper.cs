using Data.Enums;
using Data.Models;
using System;

namespace DesktopClient.BussinesModels
{
    public class CarPeriodRapper
    {
        #region Declarations
        private Car car;
        private Period period;
        private LocationRapper locationTo;
        #endregion

        #region Constructor
        public CarPeriodRapper(Car car,Period period,Locations location )
        {
            this.car = car;
            this.period = period;
            locationTo = new LocationRapper(location);
        }
        #endregion

        #region Proparties
        public string Brand
        {
            get
            {
                return car.Brand;
            }
        }
        public string Model
        {
            get
            {
                return car.Model;
            }
        }
        public int Capacity
        {
            get
            {
                return car.Capacity;
            }
        }
        public decimal Consumation
        {
            get
            {
                return car.Consumation;
            }
        }
        public int Year
        {
            get
            {
                return car.Year;
            }
        }
        public string Path
        {
            get
            {
                return car.Path;
            }
        }
        public DateTime From
        {
            get
            {
                return period.From;
            }
        }
        public DateTime To
        {
            get
            {
                return period.To;
            }
        }
        public LocationRapper LocationFrom
        {
            get
            {
                return new LocationRapper(period.Location);
            }
        }
        public LocationRapper LocationTo
        {
            get
            {
                return locationTo;
            }
        }
        public decimal TotalPrice
        {
            get
            {
                return car.Price * Days;
            }
        }
        public int Days
        {
            get
            {
                if (!period.To.TimeOfDay.Equals(period.From.TimeOfDay))
                {
                    return (period.To - period.From).Days+1;
                }
                return (period.To - period.From).Days;
            }
        }
        #endregion

        #region Methods
        public Car GetCar()
        {
            return car;
        }

        public Period GetPeriod()
        {
            return period;
        }

        public Locations GetLocationTo()
        {
            return locationTo.Location;
        }
        #endregion
    }
}
