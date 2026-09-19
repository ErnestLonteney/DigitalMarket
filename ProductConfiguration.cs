using DigitalMarket.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalMarket
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Name);
            builder.Property(p => p.Price).HasColumnType("money");
            builder.Property(p => p.Name).HasMaxLength(100);
        }
    }
}
