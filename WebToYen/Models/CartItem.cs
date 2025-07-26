 using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebToYen.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        public int CartId { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18)")]
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }

        public CartItem() { }

        public CartItem(Product product)
        {
            ProductId = product.ProductId;
            ProductName = product.Name;
            UnitPrice = product.Price;
            Quantity = 1; // Default quantity
            ProductImage = product.ProductImages.FirstOrDefault()?.ImageUrl ?? string.Empty; // Assuming ProductImage is a URL
        }
    }
}
