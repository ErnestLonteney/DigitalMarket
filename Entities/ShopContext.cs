using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMarket.Entities
{
    public class ShopContext : DbContext
    {

        public ShopContext()
        {
           // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Manager> Managers { get; set; } = null!;

        public DbSet<CustomerAddress> CustomerAddresses { get; set; } = null!;

        public DbSet<Department> Departments { get; set; } = null!;

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
            
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId);


            modelBuilder.Entity<Order>()
                .Property(o => o.Date)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.Qty)
                .HasDefaultValue(1);

            modelBuilder.ApplyConfiguration(new ProductConfiguration());


        }
    }
}
