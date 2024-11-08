using E_Ticaret_WebApplication.Data;
using E_Ticaret_WebApplication.Models;
using E_Ticaret_WebApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret_WebApplication.Repositories.Concretes
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TrendyolContext _trendyolContext;
        public CategoryRepository(TrendyolContext context)
        {
            _trendyolContext = context;
        }
        public async Task AddCategoryAsync(Category category)
        {
            _trendyolContext.Categories.Add(category);
            await _trendyolContext.SaveChangesAsync();  
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _trendyolContext.Categories.FindAsync(id);
            if (category != null) { 
            _trendyolContext.Categories.Remove(category);
                await _trendyolContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
           return await _trendyolContext.Categories.Include(c=>c.Products).ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _trendyolContext.Categories.Include(c => c.Products).FirstOrDefaultAsync(p => p.Id == id);     }

        public async Task UpdateCategoryAsync(Category category)
        {
            _trendyolContext.Categories.Update(category);
            await _trendyolContext.SaveChangesAsync();

        }
    }
}
