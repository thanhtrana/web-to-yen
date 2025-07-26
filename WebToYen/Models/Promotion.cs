using System.ComponentModel.DataAnnotations;

namespace WebToYen.Models
{
    public class Promotion
    {
        [Key]
        public int PromotionId { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }
        public string Code { get; set; }
        public int DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ProductPromotion> ProductPromotions { get; set; } = new List<ProductPromotion>();
    }
}
