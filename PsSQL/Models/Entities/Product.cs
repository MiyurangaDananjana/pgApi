using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsSQL.Models.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key, Required]
        public int Id { get; set; }
        public string? name { get; set; }
        public string? brand { get; set; }
        public int size { get; set; }
        public decimal price { get; set; }
    }
}
