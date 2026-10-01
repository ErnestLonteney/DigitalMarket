using DigitalMarket.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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

            var customer = new Customer("John", "Doe")
            {
                Phone = "1234567890"
            };

            var customerAddress = new PersonAddress
            {
                Customer = customer,
                Street = "123 Main St",
                City = "Anytown",
                House = "12A"
            };

            var order = new Order
            {
                Date = DateTime.Now,
                Customer = customer,
            };


            var orderDetail1 = new OrderDetail
            {
                Order = order,
                Product = product,
                Qty = 2
            };

            var orderDetail2 = new OrderDetail
            {
                Order = order,
                Product = product2,
                Qty = 2

            };


            var department = new Department
            {
                Name = "Sales"
            };

            var department2 = new Department
            {
                Name = "Marketing"
            };

            var manager = new Manager("Alice", "Smith")
            {
                DateStart = DateTime.Now,
                Salary = 12000,
                Phone = "213213423423",
                Email = "<EMAIL>"
            };

            var manager2 = new Manager("Bob", "Johnson")
            {
                DateStart = DateTime.Now,
                Salary = 12000,
                Phone = "234324222",
                Email = "<EMAIL>"
            };

            var director = new Director("Mikle", "Handson")
            {
                Phone = "3243246566",
                Salary = 120000,
                ActionProcent = 10
            };

            department.Managers.Add(manager);
            department.Managers.Add(manager2);
            department2.Managers.Add(manager2);

            context.Addresses.Add(customerAddress);
            context.Products.AddRange(product, product2);
            context.Orders.Add(order);
            context.Departments.AddRange(department, department2);
            context.Managers.AddRange(manager, manager2);
            context.Directors.Add(director);
            context.OrderDetails.AddRange(orderDetail1, orderDetail2);
            context.SaveChanges();

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


            var people = context.People.ToList();

            Console.WriteLine(new String('-', 50));

            foreach (Person p in people)
            {
                Console.WriteLine($"FirstName {p.FirstName}");
                Console.WriteLine($"LastName {p.LastName}");
                Console.WriteLine($"Email {p.Email}");
                Console.WriteLine($"Phone {p.Phone}");
            }

            Console.WriteLine(new String('-', 50));

            var employees = context.Employees.ToList();

            Console.WriteLine(new String('-', 50));

            foreach (Employee p in employees)
            {
                Console.WriteLine($"FirstName {p.FirstName}");
                Console.WriteLine($"LastName {p.LastName}");
                Console.WriteLine($"Email {p.Email}");
                Console.WriteLine($"Phone {p.Phone}");
                Console.WriteLine($"Salary {p.Salary}");

                if (p.Address is not null)
                {
                    Console.WriteLine($"  Address: {p.Address.Street}, {p.Address.City}, {p.Address.House}");
                }

                Console.WriteLine(new String('*', 50));
            }

            Console.WriteLine(new String('-', 50));


            var direcors = context.Directors.ToList();

            Console.WriteLine(new String('-', 50));

            foreach (Director p in direcors)
            {
                Console.WriteLine($"FirstName {p.FirstName}");
                Console.WriteLine($"LastName {p.LastName}");
                Console.WriteLine($"Email {p.Email}");
                Console.WriteLine($"Phone {p.Phone}");
                Console.WriteLine($"Salary {p.Salary}");
                Console.WriteLine($"Action procent {p.ActionProcent}");

                if (p.Address is not null)
                {
                    Console.WriteLine($"  Address: {p.Address.Street}, {p.Address.City}, {p.Address.House}");
                }

                Console.WriteLine(new String('*', 50));
            }

            Console.WriteLine(new String('-', 50));

            // Queries 

            IQueryable<Product> query1 = context.Products.Where(p => p.Price > 10);

            query1 = query1
                .Where(p => p.Name.StartsWith("Product"))
                .OrderByDescending(p => p.Price)
                .ThenBy(p => p.Name);

            Console.WriteLine(query1.ToQueryString());

            foreach (Product p in query1)
            {
                Console.WriteLine($"Name ={p.Name} Price ={p.Price}");
            }

            IEnumerable<Product> query2 = context.Products.Where(p => p.Price > 10).ToList();

            query2.Where(p => p.Name.StartsWith("Product"));

            foreach (Product p in query2)
            {
                Console.WriteLine($"Name ={p.Name}");
            }

            var query3 = from p in context.Products
                         where p.Price > 10 && p.Name.StartsWith("Product")
                         orderby p.Price descending, p.Name
                         select p;

            foreach (Product product22 in query3)
            {
                Console.WriteLine($"Name ={product22.Name} Price ={product22.Price}");
            }

            var query4 = context.Products
                .Where(p => p.Price > 10)
                .Where(p => p.Name.StartsWith("Product"))
                .OrderByDescending(p => p.Price)
                .ThenBy(p => p.Name)
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price
                });

            Console.WriteLine(query4.ToQueryString());

            foreach (var p in query4)
            {
                Console.WriteLine($"Name = {p.Name} Price = {p.Price}");
            }

            var query5 = context.Orders
                  .Include(o => o.OrderDetails)
                  .ThenInclude(d => d.Product)
                  .Include(o => o.Manager)
                  .Include(o => o.Customer);

            Console.WriteLine(query5.ToQueryString());

            foreach (var ord in query5)
            {
                Console.WriteLine($"Order ID: {ord.Id}, Date: {ord.Date}, Customer: {ord.Customer.FirstName} {ord.Customer.LastName}");
                foreach (var detail in ord.OrderDetails)
                {
                    Console.WriteLine($"  Product: {detail.Product.Name}, Quantity: {detail.Qty}");
                }
            }

            var query6 = context.OrderDetails.Include(d => d.Product)
                        .GroupBy(od => od.ProductId);

            Console.WriteLine(query6.ToQueryString());

            foreach (var group in query6)
            {
                Console.WriteLine($"Group: {group.Key}");
                foreach (var detail in group)
                {
                    Console.WriteLine($"  Product: {detail.Product.Name}, Quantity: {detail.Qty}");
                }
            }

            var query7 = context.OrderDetails
                        .GroupBy(od => od.ProductId)
                        .Select(g => new
                        {
                            Name = g.Key,
                            SumOfCount = g.Count()
                        });

            Console.WriteLine(query7.ToQueryString());

            foreach (var item in query7)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.SumOfCount);
            }

            var query8 = from od in context.OrderDetails
             group od by od.ProductId;


            Console.WriteLine(query8.ToQueryString());

            foreach (var grp in query8)
            {
                Console.WriteLine(grp.Key);
                Console.WriteLine(grp.Count());
            }


            var query9 = context.Products.Skip(5).Take(10);


            var query10 = context.Orders.Where(o => o.Date > new DateTime(2008, 1, 1) && o.Date < new DateTime(2026, 9, 27));

            Console.WriteLine(query10.ToQueryString());


            var orders = query10.ToList();

            Order? bestOrder = orders.FirstOrDefault(o => o.Date.Day == 26);

            if (bestOrder is not null)
            {
                context.Entry(bestOrder)
                      .Reference(o => o.Customer)
                      .Load();

                context.Entry(bestOrder)
                     .Collection(o => o.OrderDetails)
                     .Load();



                Console.WriteLine(bestOrder.Date);
                Console.WriteLine($"Customer = {bestOrder.Customer.FirstName} {bestOrder.Customer.LastName}");
                foreach (OrderDetail orderDetail in bestOrder.OrderDetails)
                {
                    context.Entry(orderDetail)
                        .Reference(od => od.Product)
                        .Load();

                    Console.WriteLine($"Product Name = {orderDetail.Product.Name}");
                    Console.WriteLine($"Quontity = {orderDetail.Qty}");
                }
            }

            var products = context.Products.FromSqlRaw("SELECT * FROM PRODUCTS").OrderBy(p => p.Price).ToList();

            foreach (Product p in products)
            {
                Console.WriteLine($"Name={p.Name}");
                Console.WriteLine($"Price={p.Price}");
            }

            Console.WriteLine("Input name of product");
            string name = Console.ReadLine() ?? string.Empty;

            // DON`T DO LIKE THIS
           // var product = context.Products.FromSqlRaw("SELECT TOP(1) * FROM PRODUCTS WHERE NAME = @name", name).SingleOrDefault();

            // DO LIKE THIS 
            var param = new SqlParameter("@name", name);
            var productByName = context.Products.FromSqlRaw("SELECT TOP(1) * FROM PRODUCTS WHERE NAME = @name", param).SingleOrDefault();


            if (productByName is not null)
            {
                Console.WriteLine($"Name={productByName.Name}");
                Console.WriteLine($"Price={productByName.Price}");
            }

            //var param2 = new SqlParameter("@maxPrice", 20);
            //var products2 = context.Products.FromSqlRaw("[dbo].[sp_LowerPriceProducts] @maxPrice", param2);

            //foreach (Product p in products2)
            //{
            //    Console.WriteLine($"Name={p.Name}");
            //    Console.WriteLine($"Price={p.Price}");
            //}
        }
    }
}
