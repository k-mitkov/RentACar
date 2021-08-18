using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public Period Period { get; set; }
        public Client Client { get; set; }
    }
}
