using System.ComponentModel.DataAnnotations;

namespace WebToYen.Models
{
    public class Banner
    {
        [Key]
        public int BannerId { get; set; }
        [StringLength(100)]
        public string ImageUrl { get; set; }
        [StringLength(100)]
        public string LinkTo { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public string Position { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; } = 0;
    }
}
