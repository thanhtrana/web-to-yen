using Microsoft.EntityFrameworkCore;
using WebToYen.Models;
using WebToYen.Repository;

namespace WebToYen.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _datacontext;

        public ProductService(DataContext datacontext)
        {
            _datacontext = datacontext;
        }
        public async Task<List<Models.Product>> GetSalePartialProductAsync()
        {
            return await _datacontext.Products
                .Where(p => p.DiscountPrice != null && p.DiscountPrice < p.Price)
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .ToListAsync();
        }


        public async Task<IEnumerable<Product>> GetProductsByKeywordsAsync(List<string> keywords)
        {
            return await _datacontext.Products
                .Include(p => p.ProductImages)
                .Where(p => p.Stock > 0 && keywords.Any(k => p.Name.Contains(k)))
                .OrderBy(p => p.ProductId)
                .ToListAsync();
        }


        public async Task<IEnumerable<Product>> GetYctPartialProductAsync(List<string> keywords)
        {
            return await _datacontext.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Where(p => p.Stock > 0 && keywords.Any(k => p.Name.Contains(k)))
                .OrderBy(p => p.ProductId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetYenBienPartialProductsAsync(List<string> keywords)
        {
            return await _datacontext.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Where(p => p.Stock > 0 && keywords.Any(k => p.Name.Contains(k)))
                .OrderBy(p => p.ProductId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetYenDaoPartialProductsAsync(List<string> keywords)
        {
            return await _datacontext.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Where(p => p.Stock > 0 && keywords.Any(k => p.Name.Contains(k)))
                .OrderBy(p => p.ProductId)
                .ToListAsync();
        }


        public async Task<IEnumerable<Product>> GetSanPhamKhacPartialProductsAsync(List<string> keywords)
        {
            return await _datacontext.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Where(p => p.Stock > 0 && keywords.Any(k => p.Name.Contains(k)))
                .OrderBy(p => p.ProductId)
                .ToListAsync();
        }
    }


}

