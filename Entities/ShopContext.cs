using Microsoft.EntityFrameworkCore;

namespace DigitalMarket.Entities
{
    public class ShopContext : DbContext
    {

        public ShopContext()
        {
             Database.EnsureDeleted();
             Database.EnsureCreated();

           // Database.Migrate();
        }

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Manager> Managers { get; set; } = null!;

        public DbSet<Person> People { get; set; } = null!;

        public DbSet<Employee> Employees { get; set; } = null!;

        public DbSet<Director> Directors { get; set; } = null!;

        public DbSet<PersonAddress> Addresses { get; set; } = null!;

        public DbSet<Department> Departments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ShopManagement;Trusted_Connection=True;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            //modelBuilder.Entity<Person>().ToTable("People").UseTpcMappingStrategy();
            //modelBuilder.Entity<Customer>().ToTable("Customers");
            //modelBuilder.Entity<Manager>().ToTable("Managers");
            //modelBuilder.Entity<Director>().ToTable("Directors");
        }
    }
}
