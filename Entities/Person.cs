using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMarket.Entities
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            LastName = lastName;
            FirstName = firstName;
        }

        protected Person()
        {
            
        }


        [Key]
        public int Id { get; private set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string? LastName { get; set; }

        [Column("PhoneNumber")]
        [Required]
        [MaxLength(20)]
        public required string Phone { get; set; }

        [MaxLength(200)]
        public string? Email { get; set; }

        public PersonAddress? Address { get; set; }
    }
}
