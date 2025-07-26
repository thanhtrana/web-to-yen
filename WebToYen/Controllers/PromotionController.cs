using Microsoft.AspNetCore.Mvc;

namespace WebToYen.Controllers
{
    public class PromotionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
