using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebToYen.Models;

namespace WebToYen.Repository
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<Models.Category> Categories { get; set; }
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.ProductImage> ProductImages { get; set; }
        public DbSet<Models.ProductPromotion> ProductPromotions { get; set; }
        public DbSet<Models.Promotion> Promotions { get; set; }
        public DbSet<Models.Review> Reviews { get; set; }
        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.OrderItem> OrderItems { get; set; }
        public DbSet<Models.Cart> Carts { get; set; }
        public DbSet<Models.CartItem> CartItems { get; set; }
        public DbSet<Models.Banner> Banners { get; set; }
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Models.ProductPromotion>()
        .HasKey(pp => new { pp.ProductId, pp.PromotionId });

    modelBuilder.Entity<Models.Category>()
        .HasOne(c => c.ParentCategory)
        .WithMany(c => c.SubCategories)
        .HasForeignKey(c => c.ParentId);

    modelBuilder.Entity<Models.Cart>()
        .Property(c => c.GrandlTotal)
        .HasPrecision(18, 0);  // decimal(18,0) - không phần thập phân

    base.OnModelCreating(modelBuilder);
}

    }
}
