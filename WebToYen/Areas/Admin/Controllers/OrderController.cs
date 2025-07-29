using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebToYen.Repository;

namespace WebToYen.Areas.Admin.Controllers
{


    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly DataContext _dataContext;
        public OrderController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Orders.OrderByDescending(p => p.OrderId).ToListAsync());
        }

        public async Task<IActionResult> ViewOrder(string ordercode)
        {


            var DetailsOrder = await _dataContext.OrderItems.Include(od => od.Product).Where(od=>od.OrderCode==ordercode).ToListAsync();

            return View(DetailsOrder);
        }


    }
}
