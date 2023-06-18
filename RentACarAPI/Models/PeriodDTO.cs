using DataBase.Models;

namespace RentACarAPI.Models
{
    public class PeriodDTO
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Location Location { get; set; }
    }
}
