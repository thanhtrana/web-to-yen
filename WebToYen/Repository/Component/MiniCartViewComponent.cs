using Microsoft.AspNetCore.Mvc;
using WebToYen.Models;
using WebToYen.Repository;

namespace WebToYen.Components
{
    public class MiniCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Lấy dữ liệu giỏ từ session
            var cartItems = HttpContext.Session.GetJson<List<CartItem>>("CartItems")
                           ?? new List<CartItem>();

            var model = new CartViewModel
            {
                CartItems = cartItems,
            };

            return View(model);
        }
    }
}
