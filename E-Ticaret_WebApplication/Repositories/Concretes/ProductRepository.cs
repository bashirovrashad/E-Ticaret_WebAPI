using E_Ticaret_WebApplication.Data;
using E_Ticaret_WebApplication.Models;
using E_Ticaret_WebApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret_WebApplication.Repositories.Concretes
{
    public class ProductRepository : IProductRepository
    {

        private readonly TrendyolContext _trendyolContext;
        public ProductRepository(TrendyolContext context)
        { 
            _trendyolContext = context;
        }


        public async Task AddProductAsync(Product product)
        {
           _trendyolContext.Products.Add(product);
            await _trendyolContext.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
           var product = await _trendyolContext.Products.FindAsync(id);
            if(product != null)
            {
                _trendyolContext.Products.Remove(product);
                await _trendyolContext.SaveChangesAsync();
            } 
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
           return await _trendyolContext.Products.Include(c=>c.Category).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _trendyolContext.Products.Include(c=>c.Category).FirstOrDefaultAsync(u => u.Id == id);    }

        public async Task UpdateProductAsync(Product product)
        {
           _trendyolContext.Products.Update(product);
            await _trendyolContext.SaveChangesAsync();
        }
    }
}
