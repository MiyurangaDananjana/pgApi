using System.ComponentModel.DataAnnotations.Schema;

namespace PsSQL.Models.Entities
{

    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public int Product_id { get; set; }
        public virtual Product Product { get; set; }
        public string? name { get; set; }
        public string? address { get; set; }
        public string? phone { get; set; }
    }
}
