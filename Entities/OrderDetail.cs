using Microsoft.EntityFrameworkCore;

namespace DigitalMarket.Entities
{
    [PrimaryKey(nameof(OrderId), nameof(ProductId))]
    public class OrderDetail
    {
        public Guid OrderId { get; set; }

        public int ProductId { get; set; }

        public short Qty { get; set; }
    }
}
