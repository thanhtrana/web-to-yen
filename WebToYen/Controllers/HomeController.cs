using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebToYen.Models;
using WebToYen.Repository;

namespace WebToYen.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _datacontext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _datacontext = context;
        }

        public IActionResult Index()
        {
            var products = _datacontext.Products
            .Include(p => p.ProductImages)
            .ToList();
            return View(products);
        }

        //public IActionResult SalePartialProducts()
        //{
        //    var saleProducts = _datacontext.Products
        //  .Where(p => p.DiscountPrice != null && p.DiscountPrice < p.Price)
        //  .Include(p => p.ProductImages)
        //  .ToList();

        //    return View(saleProducts);
        //}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
