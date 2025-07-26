using Microsoft.AspNetCore.Mvc;

namespace WebToYen.Controllers
{
    public class BannerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
