using WebToYen.Models;

namespace WebToYen.Services
{
    public interface IProductService
    {
        Task<List<Models.Product>> GetSalePartialProductAsync(); // sale

        Task<IEnumerable<Product>> GetProductsByKeywordsAsync(List<string> keywords);

        //Task<List<Models.Product>> GetGirtPartialProductAsync(); // qua bieu
        Task<IEnumerable<Product>> GetYctPartialProductAsync(List<string> keywords);
        // Yen chung tuoi


        Task<IEnumerable<Product>> GetYenBienPartialProductsAsync(List<string> keywords);


        Task<IEnumerable<Product>> GetYenDaoPartialProductsAsync(List<string> keywords);
        //Task<List<Models.Product>> GetYenDaoPartialProductsAsync(); // Yen dao

        Task<IEnumerable<Product>> GetSanPhamKhacPartialProductsAsync(List<string> keywords);

    }
}
