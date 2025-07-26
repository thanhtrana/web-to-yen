using Microsoft.AspNetCore.Mvc;
using WebToYen.Services; // nơi chứa IProductService

namespace WebToYen.Components
{
    public class SetQuaBieuViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public SetQuaBieuViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var keywords = new List<string> { "Yến Chưng Sẵn Cao Phẩm", "Yến Chưng Sẵn Thượng Phẩm" };

            var products = await _productService.GetProductsByKeywordsAsync(keywords);
            return View("Default", products); // Dùng chung view Default.cshtml
        }
    }
}
