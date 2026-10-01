using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalMarket.Entities
{
    [PrimaryKey(nameof(OrderId), nameof(ProductId))]
    public class OrderDetail
    {
        public Guid OrderId { get; set; }

        public int ProductId { get; set; }

        [DefaultValue(1)]
        public short Qty { get; set; }

     //   [ForeignKey(nameof(OrderId))]
        public virtual required Order Order { get; set; }

         [ForeignKey(nameof(ProductId))]
        public required Product Product { get; set; }   
    }
}
