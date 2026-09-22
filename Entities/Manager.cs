using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMarket.Entities
{
    public class Manager
    {
        public int Id { get; set; }

        public required string FirstName { get; set; } 

        public required string? LastName { get; set; }

        public string? Email { get; set; }

        public List<Order> Orders { get; set; } = [];

        public ICollection<Department> Departments { get; set; } = [];

    }
}
