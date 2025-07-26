using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using WebToYen.Repository.Validation;

namespace WebToYen.Models.ViewModels
{
    
    public class ProductCreateViewModel
    {
        [Key]
        [Required(ErrorMessage = "Yêu cầu nhập Tên Sản phẩm")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Mô tả ngắn")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Mô tả chi tiết")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Giá Sản phẩm")]
        public decimal Price { get; set; }
        public string Image { get; set; }

        [StringLength(100)]
        public string Slug { get; set; }

        public decimal? DiscountPrice { get; set; }
        public int Stock { get; set; }
        public bool IsFeatured { get; set; } = false;

        [Required(ErrorMessage = "Yêu cầu chọn Danh mục")]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = "Yêu cầu chọn ảnh sản phẩm")]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }
    }
}
