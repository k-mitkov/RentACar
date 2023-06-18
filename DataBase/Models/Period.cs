using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DataBase.Models
{
    public class Period
    {
        #region Properties

        public int Id { get; set; }
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        [JsonIgnore]
        public Car Car { get; set; }
        public int CarId { get; set; }

        #endregion
    }
}
