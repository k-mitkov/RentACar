using DataBase.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
    public class Car
    {
        #region Properties

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(50)]
        public string Model { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public VehicleType Type { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public decimal Consumation { get; set; }
        [Required]
        public int Year { get; set; }
        public string Path { get; set; }
        public List<Period> Periods { get; set; }
        public List<Reservation> Reservations { get; set; }

        #endregion
    }
}
