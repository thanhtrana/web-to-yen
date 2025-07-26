using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebToYen.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal GrandlTotal { get; set; }

        [StringLength(100)]
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
