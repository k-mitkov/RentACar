using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace DataBase.Models
{
    public class Reservation
    {
        #region Properties

        public int Id { get; set; }
        public Car Car { get; set; }
        public Period Period { get; set; }
        public Client Client { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        #endregion
    }
}
