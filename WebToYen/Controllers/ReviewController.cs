using Microsoft.AspNetCore.Mvc;

namespace WebToYen.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
