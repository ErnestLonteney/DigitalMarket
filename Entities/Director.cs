using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMarket.Entities
{
    public class Director : Employee
    {
        public Director(string firstName, string lastName)
        {
            LastName = lastName;
            FirstName = firstName;
        }

        protected Director()
        {

        }

        public byte ActionProcent { get; set; }
    }
}
