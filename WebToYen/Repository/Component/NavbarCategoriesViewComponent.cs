// File: Repository/Component/NavbarCategoriesViewComponent.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebToYen.Models;

namespace WebToYen.Repository.Component
{
    public class NavbarCategoriesViewComponent : ViewComponent
    {
        private readonly DataContext _context;

        public NavbarCategoriesViewComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories
                .Include(c => c.SubCategories)
                .Where(c => c.ParentId == null)
                .ToListAsync();

            return View(categories);
        }
    }
}
