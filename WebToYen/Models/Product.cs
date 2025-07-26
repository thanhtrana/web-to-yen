using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebToYen.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required, StringLength(100, ErrorMessage = "Yêu cầu nhập Tên Sản phẩm")]
        public string Name { get; set; }
        [Required, StringLength(100)]
        public string ShortDescription { get; set; }

        [Required, StringLength(1000,ErrorMessage ="Yêu cầu nhập Mô tả Sản phẩm")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập Giá Sản phẩm")]
        [Column(TypeName = "decimal(18,0)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal? DiscountPrice { get; set; }

        public int Stock { get; set; }

        [NotMapped] // 👈 Không lưu vào DB
        public IFormFile? ImageUpload { get; set; }

        public string? Image { get; set; }// 👈 Lưu tên file ảnh vào DB

        [StringLength(100)]
        public string Slug { get; set; }

        public bool IsFeatured { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "Yêu cầu chọn Danh mục")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public virtual ICollection<ProductPromotion> ProductPromotions { get; set; } = new List<ProductPromotion>();
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
