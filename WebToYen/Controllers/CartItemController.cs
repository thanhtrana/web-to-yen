using Microsoft.AspNetCore.Mvc;
using WebToYen.Models;
using WebToYen.Repository;

namespace WebToYen.Controllers
{
    public class CartItemController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }
    }
}
