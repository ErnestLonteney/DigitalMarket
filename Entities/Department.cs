using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMarket.Entities
{
    public class Department
    {
        public int Id { get; set; } 

        public string Name { get; set; } = null!;

        public ICollection<Manager> Managers { get; set; } = [];
    }
}
