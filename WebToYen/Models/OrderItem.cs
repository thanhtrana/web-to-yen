using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebToYen.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }

        public string OrderCode { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18)")]
        public decimal UnitPrice { get; set; }

        public virtual Order Order { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
