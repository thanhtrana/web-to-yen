//using Microsoft.EntityFrameworkCore;
//using WebToYen.Models;

//namespace WebToYen.Repository
//{
//    public class SeedData
//    {
//        public static void SeedingData(DataContext _context)
//        {
//            _context.Database.Migrate();
//            if (!_context.Products.Any())
//            {
//                Category ToYen = new Category
//                {
//                    Name = "Tổ Yến",
//                    Slug = "Tổ Yến",
//                    DisplayOrder = 1,
//                    IsActive = true,
//                    Image = "~/image/logo-to-yen.webp"
//                };
                
//                _context.Categories.Add(ToYen);
//                _context.SaveChanges();

//                Category YenChungTuoi = new Category
//                {
//                    Name = "Yến Chưng Tươi",
//                    Slug = "Yến Chưng Tươi",
//                    DisplayOrder = 2,
//                    IsActive = true,
//                    Image = "~/image/logo-yen-chung-tuoi.webp"

//                };
//                _context.Categories.Add(YenChungTuoi);
//                _context.SaveChanges();

//                // 👉 Lúc này ToYen đã có CategoryId thật (ví dụ: 1)

//                Category ToYenTho = new Category
//                {
//                    Name = "Tổ Yến Thô Nguyên Tổ",
//                    Slug = "Tổ Yến Thô Nguyên Tổ",
//                    DisplayOrder = 1,
//                    IsActive = true,
//                    ParentId = ToYen.CategoryId


//                };
//                Category ToYenTinhChe = new Category
//                {
//                    Name = "Tổ Yến Tinh Chế",
//                    Slug = "Tổ Yến Tinh Chế",
//                    DisplayOrder = 2,
//                    IsActive = true,
//                    ParentId = ToYen.CategoryId


//                };
//                _context.Categories.AddRange(ToYenTho, ToYenTinhChe);
//                _context.SaveChanges();
//                // 👉 Lúc này ToYenTho đã có CategoryId thật (ví dụ: 3) và ToYenTinhChe cũng vậy (ví dụ: 4)

//                Product product1 = new Product
//                {
//                    Name = "Tổ Yến Thô Nguyên Tổ",
//                    ShortDescription = "Sản phẩm cao cấp từ Khánh Hòa",
//                    Description = "Tổ Yến Thô Nguyên Tổ là sản phẩm yến sào nguyên chất, chưa qua tinh chế.",
//                    Price = 1000000,
//                    Category = ToYen,
//                };
//                Product product2 = new Product
//                {
//                    Name = "Yến Sào Khánh Hòa",
//                    ShortDescription = "Sản phẩm cao cấp từ Khánh Hòa",
//                    Description = "Yến Sào Khánh Hòa là sản phẩm yến sào chất lượng cao, được sản xuất từ tổ yến tự nhiên.",
//                    Price = 1500000,

//                    Category = ToYen,

//                };
//                _context.Products.Add(product1);
//                    _context.Products.Add(product2);
                

//                _context.SaveChanges();

//                // 👉 Lúc này product1 đã có ProductId thật (ví dụ: 1) và product2 cũng vậy (ví dụ: 2)

//                ProductImage image1 = new ProductImage
//                {
//                    ProductId = product1.ProductId,
//                    ImageUrl = "set-qua-cao-cap.webp",
//                    AltText = "Yến Sào Khánh Hòa",
//                    IsPrimary = true
//                };
//                ProductImage image2 = new ProductImage
//                {
//                    ProductId = product1.ProductId,
//                    ImageUrl = "set-qua-tet.webp",
//                    AltText = "Yến Sào Khánh Hòa",
//                    IsPrimary = true,
//                };
//                _context.ProductImages.AddRange(image1, image2);
//                _context.SaveChanges();
//            }
//        }
//    }
//}
