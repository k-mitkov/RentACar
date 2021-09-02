using Data.Enums;
using System.Collections.Generic;

namespace Data.Models
{
    public class Car
    {
        #region Proparties
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public TypeVehicle Type { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public decimal Consumation { get; set; }
        public int Year { get; set; }
        public string Path { get; set; }
        public List<Period> Periods { get; set; }
        public List<Reservation> Reservations { get; set; }
        #endregion
    }
}
