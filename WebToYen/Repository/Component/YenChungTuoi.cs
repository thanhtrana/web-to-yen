using Microsoft.AspNetCore.Mvc;
using WebToYen.Services; // nơi chứa IProductService

namespace WebToYen.Components
{
    public class YenChungTuoi : ViewComponent
    {
        private readonly IProductService _productService;

        public YenChungTuoi(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var keywords = new List<string> { "Yến Chưng" };

            var products = await _productService.GetYctPartialProductAsync(keywords);
            return View("Default", products); // Dùng chung view Default.cshtml
        }
    }
}
