using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebToYen.Repository.Component
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly DataContext _dataContextt;
        public CategoriesViewComponent(DataContext context)
        {
            _dataContextt = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()

            =>View(await _dataContextt.Categories.ToListAsync());



    } 
}
