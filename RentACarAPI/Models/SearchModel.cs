using DataBase.Enums;

namespace RentACarAPI.Models
{
    public class SearchModel
    {
        public DateTime FromDate { get;set; }
        public DateTime ToDate { get;set; }
        public VehicleType Type { get; set; }
        public int LocationId { get; set; }
    }
}
