using Data.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Period
    {
        #region Proparties
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Locations Location { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
        #endregion
    }
}
