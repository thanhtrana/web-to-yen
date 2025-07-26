using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebToYen.Models;
using WebToYen.Repository;
using X.PagedList;
using X.PagedList.Extensions;
using X.PagedList.Mvc.Core;

namespace WebToYen.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _datacontext;

        public ProductController(DataContext context)
        {
            _datacontext = context;
        }

        //public async Task<IActionResult> Category(int id)
        //{

        //    var categorys = await _datacontext.Categories
        //        .Where(p => p.ParentId == id)
        //        .Select(c =>c.CategoryId)
        //        .ToListAsync();
        //    categorys.Add(id);

        //    var products = await _datacontext.Products
        //        .Where(p => categorys.Contains(p.CategoryId))
        //        .ToListAsync();

        //    return View(products);
        //}


        public async Task<IActionResult> Category(int id, string? sortOrder , int? categoryId)
        {

            ViewBag.CurrentCategoryId = id;
            ViewBag.CurrentSortOrder = sortOrder;

            // Lấy danh mục được chọn

            var selectedCategory = await _datacontext.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);

            if (selectedCategory == null)
            {
                return NotFound();
            }

            // Danh sách ID danh mục để lọc sản phẩm
            List<int> categoryIds;

            // Nếu là danh mục cha (ParentId == null), lấy luôn các danh mục con
            if (selectedCategory.ParentId == null)
            {
                categoryIds = await _datacontext.Categories
                    .Where(c => c.ParentId == id)
                    .Select(c => c.CategoryId)
                    .ToListAsync();

                categoryIds.Add(id); // Thêm danh mục cha
            }
            else
            {
                // Nếu là danh mục con, chỉ lấy chính nó
                categoryIds = new List<int> { id };
            }

            // Khởi tạo truy vấn, chưa gọi ToListAsync
            var productsQuery = _datacontext.Products
                .Include(p => p.ProductImages)
                .Where(p => categoryIds.Contains(p.CategoryId) && p.Stock > 0);


            // Áp dụng sắp xếp
            productsQuery = sortOrder switch
            {
            "price-ascending" => productsQuery.OrderBy(p => p.Price),
            "price-descending" => productsQuery.OrderByDescending(p => p.Price),
            "title-ascending" => productsQuery.OrderBy(p => p.Name),
            "title-descending" => productsQuery.OrderByDescending(p => p.Name),
            _ => productsQuery.OrderBy(p => p.ProductId)
            };

            var products = await productsQuery.ToListAsync();

            return View(products);
        }


        public IActionResult Index()

        {
            return View();
        }
        public IActionResult Details(int id)
        {
            //if (id == null) return RedirectToAction("Index");
            var products = _datacontext.Products
                .Include(P => P.ProductImages)
                .FirstOrDefault(p => p.ProductId == id);
                
            if(products == null)
            {
                return NotFound();
            }
            return View(products);
        }




        public async Task<IActionResult> All(int? page, string sortOrder)
        {
            int pageSize = 12;
            int pageNumber = page ?? 1;




            var products = _datacontext.Products
                .Include(p => p.ProductImages) // BẮT BUỘC để tránh lỗi null
                .AsQueryable();





            ViewBag.CurrentSortOrder = sortOrder;
            products = sortOrder switch
            {
                "price-ascending" => products.OrderBy(p => p.Price),
                "price-descending" => products.OrderByDescending(p => p.Price),
                "title-ascending" => products.OrderBy(p => p.Name),
                "title-descending" => products.OrderByDescending(p => p.Name),
                _ => products.OrderBy(p => p.ProductId)
            };


            // 👉 Truyền ViewBag.Categories (chỉ danh mục cha)
            var categories = await _datacontext.Categories
                .Where(c => c.ParentId == null && c.IsActive)
                .Include(c => c.SubCategories) // nếu bạn vẫn cần load sub
                .ToListAsync();

            ViewBag.Categories = categories;

            var pagedList =  products.ToPagedList(pageNumber, pageSize);


            return View(pagedList);
        }





    }
}
