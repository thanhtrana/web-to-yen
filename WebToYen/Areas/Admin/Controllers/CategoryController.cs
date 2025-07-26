using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using WebToYen.Models;
using WebToYen.Repository;

namespace WebToYen.Areas.Admin.Controllers
{
        [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _environment;
        public CategoryController(DataContext context, IWebHostEnvironment environment)
        {
            _dataContext = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Categories.OrderByDescending(p => p.CategoryId).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.ParentCategories = new SelectList(
       _dataContext.Categories.Where(c => c.ParentId == null),
       "CategoryId",
       "Name"
        );
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category , IFormFile? ImageUpload)
        {
            
            if (ModelState.IsValid)
            {
                category.Slug = category.Name.Replace(" ", "-");
                var slug = await _dataContext.Categories.FirstOrDefaultAsync(p => p.Slug == category.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Danh muc đã tồn tại trong hệ thống.");
                    return View(category);
                }

                // 👉 Lưu sản phẩm trước để có ProductId

                // Xử lý upload ảnh
                if (ImageUpload != null && ImageUpload.Length > 0)
                {
                    string uploadsDir = Path.Combine(_environment.WebRootPath, "media/categories");

                    Directory.CreateDirectory(uploadsDir); // tạo folder nếu chưa có

                    string imageName = Guid.NewGuid().ToString() + Path.GetExtension(ImageUpload.FileName);
                    string filePath = Path.Combine(uploadsDir, imageName);

                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageUpload.CopyToAsync(fs);
                    }

                    category.Image = imageName;
                }

                _dataContext.Categories.Add(category);
                await _dataContext.SaveChangesAsync();

                TempData["success"] = "Tạo danh mục thành công!";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Tạo danh mục thất bại.";
            ViewBag.ParentCategories = new SelectList(
    _dataContext.Categories.Where(c => c.ParentId == null),
    "CategoryId",
    "Name");
            return View(category);

        }



        public async Task<IActionResult> Edit(int id)
        {

            var existingCategory = await _dataContext.Categories.FindAsync(id);


            return View(existingCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category, IFormFile? ImageUpload)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra slug trùng (ngoại trừ category đang chỉnh sửa)
                var slug = await _dataContext.Categories
                    .FirstOrDefaultAsync(p => p.Slug == category.Name.Replace(" ", "-") && p.CategoryId != category.CategoryId);

                if (slug != null)
                {
                    ModelState.AddModelError("", "Danh mục đã tồn tại trong hệ thống.");
                    return View(category);
                }

                // Lấy category cũ từ database
                var existingCategory = await _dataContext.Categories.FindAsync(category.CategoryId);
                if (existingCategory == null)
                    return NotFound();

                existingCategory.Name = category.Name;
                existingCategory.Slug = category.Name.Replace(" ", "-");
                existingCategory.ParentId = category.ParentId;
                existingCategory.DisplayOrder = category.DisplayOrder;
                existingCategory.IsActive = category.IsActive;

                if (ImageUpload != null && ImageUpload.Length > 0)
                {
                    // Xóa ảnh cũ nếu tồn tại
                    if (!string.IsNullOrEmpty(existingCategory.Image) &&
                        !string.Equals(existingCategory.Image, "noname.jpg", StringComparison.OrdinalIgnoreCase))
                    {
                        string uploadsDir = Path.Combine(_environment.WebRootPath, "media/categories");
                        string oldFilePath = Path.Combine(uploadsDir, existingCategory.Image);
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                    // Upload ảnh mới
                    string uploadsDirNew = Path.Combine(_environment.WebRootPath, "media/categories");
                    Directory.CreateDirectory(uploadsDirNew);

                    string imageName = Guid.NewGuid().ToString() + Path.GetExtension(ImageUpload.FileName);
                    string filePath = Path.Combine(uploadsDirNew, imageName);

                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageUpload.CopyToAsync(fs);
                    }

                    existingCategory.Image = imageName;
                }

                await _dataContext.SaveChangesAsync();

                TempData["success"] = "Cập nhật danh mục thành công!";
                return RedirectToAction("Index");
            }

            TempData["error"] = "Cập nhật danh mục thất bại.";
            ViewBag.ParentCategories = new SelectList(
                _dataContext.Categories.Where(c => c.ParentId == null),
                "CategoryId",
                "Name");
            return View(category);
        }


        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _dataContext.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            // Kiểm tra ảnh có tồn tại và không phải ảnh mặc định
            if (!string.IsNullOrEmpty(category.Image) &&
                !string.Equals(category.Image, "noname.jpg", StringComparison.OrdinalIgnoreCase))
            {
                string uploadsDir = Path.Combine(_environment.WebRootPath, "media/categories");
                string oldFilePath = Path.Combine(uploadsDir, category.Image);
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
            }

            _dataContext.Categories.Remove(category);
            await _dataContext.SaveChangesAsync();

            TempData["error"] = "Danh mục đã được xóa.";
            return RedirectToAction("Index");
        }



    }

}
