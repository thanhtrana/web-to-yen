using Microsoft.AspNetCore.Mvc;

namespace WebToYen.Controllers
{
    public class ProductPromotionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
