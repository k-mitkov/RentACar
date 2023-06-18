using DataBase.Enums;

namespace RentACarAPI.Models
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public VehicleType Type { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public decimal Consumation { get; set; }
        public int Year { get; set; }
        public string Path { get; set; }
        public List<PeriodDTO> Periods { get; set; }
    }
}
