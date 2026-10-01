

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? Artikul { get; set; }

        public string? Discription { get; set; }
    }
}