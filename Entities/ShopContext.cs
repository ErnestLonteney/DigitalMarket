using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMarket.Entities
{
    public class ShopContext : DbContext
    {

        public ShopContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        public DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ShopManagement;Trusted_Connection=True;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });
       

            modelBuilder.Entity<Customer>()
                .Property(c => c.FirstName)
                .HasMaxLength(100);

            modelBuilder.Entity<Customer>().Property(p => p.Phone)
                .HasColumnName("PhoneNumber");      

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
