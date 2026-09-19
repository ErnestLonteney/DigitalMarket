using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMarket.Entities
{ 
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public DateTime Date { get; set; }

        public int CustomerId { get; set; }
    }
}
