using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Admin
    {
        #region Proparties

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Mail { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        #endregion
    }
}
