using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Client
    {
        #region Proparties
        public int Id { get; set; }
        public string Mail { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Reservation> Reservations { get; set; }
        #endregion
    }
}
