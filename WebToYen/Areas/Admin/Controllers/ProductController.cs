using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebToYen.Models;
using WebToYen.Models.ViewModels;
using WebToYen.Repository;

namespace WebToYen.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _environment;

        public ProductController(DataContext context, IWebHostEnvironment environment)
        {
            _dataContext = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Products.OrderByDescending(p => p.ProductId).Include(p => p.Category).ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, List<IFormFile> ImageUploads)
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "CategoryId", "Name", product.CategoryId);

            if (ModelState.IsValid)
            {
                product.Slug = product.Name.Replace(" ", "-");
                var slug = await _dataContext.Products.FirstOrDefaultAsync(p => p.Slug == product.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Sản phẩm đã tồn tại trong hệ thống.");
                    return View(product);
                }

                // 👉 Lưu sản phẩm trước để có ProductId
                _dataContext.Products.Add(product);
                await _dataContext.SaveChangesAsync();

                if (ImageUploads != null && ImageUploads.Any())
                {
                    string uploadsDir = Path.Combine(_environment.WebRootPath, "media/products");
                    bool isFirst = true;

                    foreach (var file in ImageUploads)
                    {
                        if (file != null && file.Length > 0)
                        {
                            string imageName = Guid.NewGuid().ToString() + "_" + file.FileName;
                            string filePath = Path.Combine(uploadsDir, imageName);

                            using (var fs = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(fs);
                            }

                            var productImage = new ProductImage
                            {
                                ProductId = product.ProductId,
                                ImageUrl = imageName,
                                AltText = product.Name,
                                IsPrimary = isFirst // Ảnh đầu tiên sẽ là ảnh chính
                            };

                            if (isFirst)
                            {
                                product.Image = imageName; // Gán vào Product.Image (nếu bạn vẫn dùng)
                                isFirst = false;
                            }

                            _dataContext.ProductImages.Add(productImage);
                        }
                    }

                    await _dataContext.SaveChangesAsync();
                }

                TempData["success"] = "Thêm sản phẩm thành công!";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Có lỗi xảy ra khi thêm sản phẩm.";
            return View(product);
        }




        public async Task<IActionResult> Edit (int id)
        {
            Product product = await _dataContext.Products.FindAsync(id);
            ViewBag.Categories = new SelectList(_dataContext.Categories, "CategoryId", "Name", product.CategoryId);

            return View(product);

        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id,Product product)
        //{
        //    ViewBag.Categories = new SelectList(_dataContext.Categories, "CategoryId", "Name", product.CategoryId);

        //    if (ModelState.IsValid)
        //    {
        //        product.Slug = product.Name.Replace(" ", "-");
        //        var slug = await _dataContext.Products.FirstOrDefaultAsync(p => p.Slug == product.Slug);
        //        if (slug != null)
        //        {
        //            ModelState.AddModelError("", "San pham da co trong Database");
        //            return View(product);
        //        }


        //        if (product.ImageUpload != null)
        //        {
        //            string uploadsDir = Path.Combine(_environment.WebRootPath, "media/products");
        //            string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
        //            string filePath = Path.Combine(uploadsDir, imageName);

        //            FileStream fs = new FileStream(filePath, FileMode.Create);
        //            await product.ImageUpload.CopyToAsync(fs);
        //            fs.Close();
        //            product.Image = imageName;

        //        }

        //        _dataContext.Update(product);
        //        await _dataContext.SaveChangesAsync(); // 👈 Cần thiết để lưu DB

        //        TempData["success"] = "Cap Nhat San Pham Thanh Cong";
        //        return RedirectToAction("Index");

        //    }
        //    else
        //    {
        //        TempData["error"] = "Model Co Mot So Cho Bi Loi";

        //        List<string> errors = new List<string>();
        //        foreach (var value in ModelState.Values)
        //        {
        //            foreach (var error in value.Errors)
        //            {
        //                errors.Add(error.ErrorMessage);
        //            }
        //        }
        //        string errorMessage = string.Join("\n", errors);
        //        return BadRequest(errorMessage);
        //    }
        //    return View(product);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "CategoryId", "Name", product.CategoryId);

            if (!ModelState.IsValid)
            {
                TempData["error"] = "Model có lỗi. Vui lòng kiểm tra lại.";

                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }

            // 1. Lấy sản phẩm gốc từ DB
            var existingProduct = await _dataContext.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            // 2. Kiểm tra slug trùng (ngoại trừ chính nó)
            string newSlug = product.Name.Replace(" ", "-");
            var slugExists = await _dataContext.Products
                .FirstOrDefaultAsync(p => p.Slug == newSlug && p.ProductId != id);
            if (slugExists != null)
            {
                ModelState.AddModelError("", "Sản phẩm đã tồn tại.");
                return View(product);
            }

            // 3. Cập nhật thông tin
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.Slug = newSlug;

            // 4. Nếu có ảnh mới thì lưu ảnh
            if (product.ImageUpload != null)
            {
                string uploadsDir = Path.Combine(_environment.WebRootPath, "media/products");
                string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                string filePath = Path.Combine(uploadsDir, imageName);

                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    await product.ImageUpload.CopyToAsync(fs);
                }

                existingProduct.Image = imageName;
            }

            // 5. Lưu thay đổi
            await _dataContext.SaveChangesAsync();

            TempData["success"] = "Cập nhật sản phẩm thành công!";
            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> Delete(int id)
        //{
        //    Product product = await _dataContext.Products.FindAsync(id);
        //    if(string.Equals(product.Image,"noname.jpg"))
        //    {
        //        string uploadsDir = Path.Combine(_environment.WebRootPath, "media/products");

        //        string oldfilePath = Path.Combine(uploadsDir, product.Image);
        //        if(System.IO.File.Exists(oldfilePath)){
        //            System.IO.File.Delete(oldfilePath);
        //        }
        //    }
        //    _dataContext.Products.Remove(product);
        //    await _dataContext.SaveChangesAsync();
        //    TempData["error"] = "San Pham Da Xoa.";
        //    return RedirectToAction("Index");

        //}

        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _dataContext.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // Nếu ảnh KHÔNG phải ảnh mặc định thì xóa file vật lý
            if (!string.Equals(product.Image, "noname.jpg", StringComparison.OrdinalIgnoreCase))
            {
                string uploadsDir = Path.Combine(_environment.WebRootPath, "media/products");
                string oldFilePath = Path.Combine(uploadsDir, product.Image);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
            }

            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync();

            TempData["error"] = "Sản phẩm đã được xóa.";
            return RedirectToAction("Index");
        }



    }
}
