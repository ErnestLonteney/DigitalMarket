using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DigitalMarket.Entities
{
    public class CustomerAddress
    {
        [Key]
        public int CustomerId { get; set; }

        public string City { get; set; } = null!;

        public string Street { get; set; } = null!;

        public required string House { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public required Customer Customer { get; set; }
    }
}
