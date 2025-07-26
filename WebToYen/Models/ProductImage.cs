using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebToYen.Models
{
    public class ProductImage
    {
        [Key]
        public int ProductImageId { get; set; }
        public int ProductId { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public int DisplayOrder { get; set; } = 0;
        public bool IsPrimary { get; set; } = false;

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [NotMapped]
        [FileExtensions]
        public IFormFile ImageUpload {  get; set; }
    }
}
