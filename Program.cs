using DigitalMarket.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new ShopContext();

          //  var product = new Product
          //  {
          //      Name = "Product 1",
          //      Price = 10.99m,
          //      Artikul = "P001"
          //  };

          //  Product product2 = new()
          //  {
          //      Name = "Product 2",
          //      Artikul = "P002",
          //      Price = 23.56m
          //  };

          //  var customer = new Customer
          //  {
          //      FirstName = "John",
          //      LastName = "Doe",
          //      Phone = "1234567890"
          //  };

          //  var customerAddress = new CustomerAddress
          //  {
          //      Customer = customer,
          //      Street = "123 Main St",
          //      City = "Anytown",
          //      House = "12A"
          //  };

          //  context.CustomerAddresses.Add(customerAddress);
          //  context.Products.AddRange(product, product2);
          // // context.SaveChanges();

          //  var order = new Order
          //  {
          //      Date = DateTime.Now,
          //      Customer = customer,
          //  };

          //  context.Orders.Add(order);
          ////  context.SaveChanges();

          //  var orderDetail = new OrderDetail
          //  {
          //      Order = order,
          //      Product = product,
          //      Qty = 2
          //  };

          //  var orderDetail2 = new OrderDetail
          //  {
          //      Order = order,
          //      Product = product2,
          //      Qty = 2

          //  };


          //  var department = new Department
          //  {
          //      Name = "Sales"
          //  };

          //  var department2 = new Department
          //  {
          //      Name = "Marketing"
          //  };

          //  var manager = new Manager
          //  {
          //      FirstName = "Alice",
          //      LastName = "Smith",
          //      Email = "<EMAIL>"
          //  };

          //  var manager2 = new Manager
          //  {
          //      FirstName = "Bob",
          //      LastName = "Johnson",
          //      Email = "<EMAIL>"
          //  };

          //  department.Managers.Add(manager);
          //  department.Managers.Add(manager2);
          //  department2.Managers.Add(manager2);

          //  context.Departments.AddRange(department, department2);
          //  context.Managers.AddRange(manager, manager2);
          //  context.OrderDetails.AddRange(orderDetail, orderDetail2);
          //  context.SaveChanges();

            IQueryable<Order> allOrders = context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product);

            Console.WriteLine(allOrders.ToQueryString());

            foreach (var ord in allOrders)
            {
                Console.WriteLine($"Order ID: {ord.Id}, Date: {ord.Date}, Customer: {ord.Customer.FirstName} {ord.Customer.LastName}");
                foreach (var detail in ord.OrderDetails)
                {
                    Console.WriteLine($"  Product: {detail.Product.Name}, Quantity: {detail.Qty}");
                }
            }


            List<Customer> allCustomers = context.Customers
                .Include(c => c.Address)
                .ToList();

            foreach (var cust in allCustomers)
            {
                Console.WriteLine($"Customer ID: {cust.Id}, Name: {cust.FirstName} {cust.LastName}, Phone: {cust.Phone}");

                if (cust.Address is not null)
                {
                    Console.WriteLine($"  Address: {cust.Address.Street}, {cust.Address.City}, {cust.Address.House}");
                }
            }


             var departmentsWithManagers = context.Departments
                .Include(d => d.Managers);

            var sql = departmentsWithManagers.ToQueryString();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sql);
            Console.ResetColor();

            foreach (var dept in departmentsWithManagers)
            {
                Console.WriteLine($"Department ID: {dept.Id}, Name: {dept.Name}");
                foreach (var mgr in dept.Managers)
                {
                    Console.WriteLine($"  Manager: {mgr.FirstName} {mgr.LastName}, Email: {mgr.Email}");
                }
            }

            foreach (var manager11 in context.Managers)
            {
                Console.WriteLine($"Manager: {manager11.FirstName} {manager11.LastName}, Email: {manager11.Email}");

                foreach (var dept in manager11.Departments)
                {
                    Console.WriteLine($"  Department: {dept.Name}");
                }
            }
        }
    }
}
