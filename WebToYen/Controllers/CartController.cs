using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebToYen.Models;
using WebToYen.Repository;

namespace WebToYen.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _dataContext;
        public CartController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }




        public IActionResult Index()
        {
            List<CartItem> cartItems = HttpContext.Session.GetJson<List<CartItem>>("CartItems") ?? new List<CartItem>();

            if (!cartItems.Any())
            {
                ViewBag.CartEmpty = true;
                return View(new Cart
                {
                    CartItems = new List<CartItem>(),
                    GrandlTotal = 0
                });
            }

            Cart cart = new()
            {
                CartItems = cartItems,
                GrandlTotal = cartItems.Sum(item => item.TotalPrice)
            };

            return View(cart);
        }

        public async Task<IActionResult> Add(int Id)
        {
            Product product = await _dataContext.Products
    .Include(p => p.ProductImages)
    .FirstOrDefaultAsync(p => p.ProductId == Id);
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("CartItems") ?? new List<CartItem>();
            CartItem cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("CartItems", cart);
            TempData["AddedToCart"] = true;
            return Redirect(Request.Headers["Referer"].ToString());

        }

        public async Task<IActionResult> Decrease(int Id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("CartItems");
            CartItem cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();
            if(cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.ProductId == Id);
            }
            if(cart.Count == 0)
            {
                HttpContext.Session.Remove("CartItems");

            }
            else
            {
                HttpContext.Session.SetJson("CartItems",cart);

            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Increase(int Id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("CartItems");
            CartItem cartItem = cart.Where(c => c.ProductId == Id).FirstOrDefault();
            if (cartItem.Quantity >= 1)
            {
                ++cartItem.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.ProductId == Id);
            }
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("CartItems");

            }
            else
            {
                HttpContext.Session.SetJson("CartItems", cart);

            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int Id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("CartItems");

            cart.RemoveAll(p => p.ProductId == Id);
            if(cart.Count == 0)
            {
                HttpContext.Session.Remove("CartItems");
            }
            else
            {
                HttpContext.Session.SetJson("CartItems", cart);

            }

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Clear() 
        {
            HttpContext.Session.Remove("CartItems");
            return RedirectToAction("Index");

        }




    }
}
