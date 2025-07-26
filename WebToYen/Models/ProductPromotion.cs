namespace WebToYen.Models
{
    public class ProductPromotion
    {
        public int ProductId { get; set; }
        public int PromotionId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Promotion Promotion { get; set; }
    }
}
