using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMarket.Entities
{
    public class PersonAddress
    {
        [Key]
        public int CustomerId { get; set; }

        public string City { get; set; } = null!;

        public string Street { get; set; } = null!;

        public required string House { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public required Person Customer { get; set; }
    }
}
