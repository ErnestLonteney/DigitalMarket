using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMarket.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; private set; }

        [MaxLength(100)]
        public required string FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        [Column("PhoneNumber")]
        [Required]
        [MaxLength(20)]
        public required string Phone { get; set; }

        [MaxLength(200)]
        public string? Email { get; set; }

        public CustomerAddress? Address { get; set; }

        public List<Order> Orders { get; set; } = [];
    }
}
