using Microsoft.AspNetCore.Mvc;
using WebToYen.Services; // nơi chứa IProductService

namespace WebToYen.Components
{
    public class YenDao : ViewComponent
    {
        private readonly IProductService _productService;

        public YenDao(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var keywords = new List<string> { "Set 10", "Set 20" };

            var products = await _productService.GetYenBienPartialProductsAsync(keywords);
            return View("Default", products); // Dùng chung view Default.cshtml
        }
    }
}
