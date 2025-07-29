using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebToYen.Models;
using WebToYen.Repository;

namespace WebToYen.Controllers
{
    public class CheckoutController : Controller
    {


        private readonly DataContext _datacontext;

        public CheckoutController(DataContext context)
        {
            _datacontext = context;
        }


public async Task<IActionResult> Checkout()
        {

            var userEmail = User.FindFirstValue(ClaimTypes.Email);
            if (userEmail == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var ordercode = Guid.NewGuid().ToString();
                var order = new Order();
                order.OrderCode = ordercode;
                order.UserEmail = userEmail;
                order.Status = 1;
                order.OrderDate = DateTime.Now;
                _datacontext.Add(order);
                _datacontext.SaveChanges();

                List<CartItem> cartItems = HttpContext.Session.GetJson<List<CartItem>>("CartItems") ?? new List<CartItem>();
                foreach(var cart in cartItems)
                {
                    var orderitem = new OrderItem();
                    orderitem.OrderCode = ordercode;
                    orderitem.OrderId = order.OrderId;
                    orderitem.ProductId = cart.ProductId;
                    orderitem.Quantity = cart.Quantity;
                    orderitem.UnitPrice = cart.UnitPrice;
                    _datacontext.Add(orderitem);
                    _datacontext.SaveChanges();
                }
                HttpContext.Session.Remove("CartItems");

                TempData["success"] = "Ckeck out thanh cong, vui long cho duyet don hang";
                return RedirectToAction("Index", "Cart");


            }

            return View();
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
