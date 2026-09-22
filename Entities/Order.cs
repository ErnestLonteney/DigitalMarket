using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMarket.Entities
{ 
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public DateTime Date { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = [];
      
        public Customer Customer { get; set; } = null!;

        public Manager? Manager { get; set; } = null!;
    }
}
