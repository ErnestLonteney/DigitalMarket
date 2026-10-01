using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMarket.Entities
{
    public class Employee : Person
    {
        public double Salary { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime? DateEnd { get; set; }
    }
}
