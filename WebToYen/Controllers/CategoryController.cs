using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebToYen.Repository;
using WebToYen.Models;
namespace WebToYen.Controllers
{
    public class CategoryController : Controller
    {


        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }

        // Hiển thị toàn bộ danh mục (cha và con)
        public IActionResult Index()
        {
            // Lấy toàn bộ category, bao gồm SubCategories (nếu cần)
            var categories = _context.Categories
                .Where(c => c.IsActive)
                .Include(c => c.SubCategories)
                .OrderBy(c => c.DisplayOrder)
                .ToList();

            return View(categories);
        }
    }
}
