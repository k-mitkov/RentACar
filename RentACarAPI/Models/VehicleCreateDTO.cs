using DataBase.Enums;
using System.ComponentModel.DataAnnotations;

namespace RentACarAPI.Models
{
    public class VehicleCreateDTO
    {
        [Required]
        [MaxLength(50)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(50)]
        public string Model { get; set; }
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
        [Required]
        public string Path { get; set; }
    }
}
