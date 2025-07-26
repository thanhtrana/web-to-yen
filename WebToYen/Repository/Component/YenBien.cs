using Microsoft.AspNetCore.Mvc;
using WebToYen.Services; // nơi chứa IProductService

namespace WebToYen.Components
{
    public class YenBien : ViewComponent
    {
        private readonly IProductService _productService;

        public YenBien(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var keywords = new List<string> { "Set 18 Yến Chưng", "Set 20 Yến Chưng" };

            var products = await _productService.GetYenBienPartialProductsAsync(keywords);
            return View("Default", products); // Dùng chung view Default.cshtml
        }
    }
}
