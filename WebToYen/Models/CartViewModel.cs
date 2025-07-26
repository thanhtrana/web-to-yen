namespace WebToYen.Models
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal Total => CartItems.Sum(i => i.TotalPrice);
        public int Count => CartItems.Sum(i => i.Quantity);
    }
}
