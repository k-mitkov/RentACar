using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
    public class Location
    {
        #region Properties

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        #endregion
    }
}
