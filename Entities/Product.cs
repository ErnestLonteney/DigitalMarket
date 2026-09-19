

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace DigitalMarket.Entities
{

    // [Table("SuperProducts")]
    [Index(nameof(Name))]
    public class Product
    {
        public int Id { get; private set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [MaxLength(50)]
        public required string? Artikul { get; set; } 
    }
}