using Microsoft.AspNetCore.Mvc;

namespace WebToYen.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
