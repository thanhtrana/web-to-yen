using Microsoft.AspNetCore.Mvc;
using WebToYen.Services; // nơi chứa IProductService

namespace WebToYen.Components
{
    public class SanPhamKhac : ViewComponent
    {
        private readonly IProductService _productService;

        public SanPhamKhac(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var keywords = new List<string> { "Fer" };

            var products = await _productService.GetSanPhamKhacPartialProductsAsync(keywords);
            return View("Default", products); // Dùng chung view Default.cshtml
        }
    }
}
