using Microsoft.AspNetCore.Mvc;
using WebToYen.Models;
using WebToYen.Repository;


namespace WebToYen.Components
{
    public class AddToCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Lấy giỏ hàng từ session
            var cartItems = HttpContext.Session.GetJson<List<CartItem>>("CartItems") ?? new List<CartItem>();

            // Tính tổng tiền (nếu muốn)
            decimal total = cartItems.Sum(item => item.TotalPrice);

            // Tạo model
            var model = new CartViewModel
            {
                CartItems = cartItems,
                
            };

            return View(model); // Mặc định sẽ tìm Views/Shared/Components/AddToCart/Default.cshtml
        }

    }
}
