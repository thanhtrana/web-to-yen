using Microsoft.AspNetCore.Mvc;

namespace WebToYen.Controllers
{
    public class OrderItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
