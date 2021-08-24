using Data.Enums;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopClient.BussinesModels
{
    public class CarPeriodRapper
    {
        #region Declarations
        private Car car;
        private Period period;
        private Locations locationTo;
        #endregion

        #region Constructor
        public CarPeriodRapper(Car car,Period period,Locations location )
        {
            this.car = car;
            this.period = period;
            locationTo = location;
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
                return car.Capacity;
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
        public Locations LocationFrom
        {
            get
            {
                return period.Location;
            }
        }
        public Locations LocationTo
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
                return (period.To - period.From).Days;
            }
        }
        #endregion
    }
}
