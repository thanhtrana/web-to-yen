using Microsoft.AspNetCore.Mvc;

namespace WebToYen.Repository.Component
{
    public class SalePartialProductsViewComponent : ViewComponent
    {
        public readonly Services.IProductService _productService;
        public SalePartialProductsViewComponent(Services.IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var keywords = new List<string> { "Yến Chưng Sẵn Cao Phẩm", "Yến Chưng Sẵn Thượng Phẩm" , "Tổ Yến" };

            var products = await _productService.GetProductsByKeywordsAsync(keywords);
            return View("Default", products); // Dùng chung view Default.cshtml
        }
    }
}
