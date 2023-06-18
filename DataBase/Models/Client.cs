using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
    public class Client
    {
        #region Proparties
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public List<Reservation> Reservations { get; set; }
        public User User { get; set; }
        #endregion
    }
}
