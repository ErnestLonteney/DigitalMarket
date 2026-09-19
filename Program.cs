using DigitalMarket.Entities;

namespace DigitalMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new ShopContext();

            var product = new Product
            {
                Name = "Product 1",
                Price = 10.99m,
                Artikul = "P001"
            };

            Product product2 = new()
            {
                Name = "Product 2",
                Artikul = "P002",
                Price = 23.56m
            };

            var customer = new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                Phone = "1234567890"
            };

            context.Customers.Add(customer);
            context.Products.AddRange(product, product2);
            context.SaveChanges();         

            var order = new Order
            {
                Date = DateTime.Now,
                CustomerId = customer.Id,
            };

            context.Orders.Add(order);
            context.SaveChanges();

            var orderDetail = new OrderDetail
            {
                OrderId = order.Id,
                ProductId = product.Id,
                Qty = 2
            };

            var orderDetail2 = new OrderDetail 
            {
                OrderId = order.Id, 
                ProductId = product2.Id, 
                Qty = 2 

            };

           
            context.OrderDetails.AddRange(orderDetail, orderDetail2);     
            context.SaveChanges();
        }
    }
}
