using E_Ticaret_WebApplication.Data;
using E_Ticaret_WebApplication.Models;
using E_Ticaret_WebApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret_WebApplication.Repositories.Concretes
{
    public class CartRepository : ICartRepository
    {
        private readonly TrendyolContext _trendyolContext;
        public CartRepository(TrendyolContext context)
        {
            _trendyolContext = context;
        }
        public async Task AddCartAsync(Cart cart)
        {
            _trendyolContext.Carts.Add(cart);
            await _trendyolContext.SaveChangesAsync();
        }

        public async Task DeleteCartAsync(int id)
        {
            var card = await _trendyolContext.Carts.FindAsync(id);
            if (card != null) 
            {
                _trendyolContext.Carts.Remove(card);
                await _trendyolContext.SaveChangesAsync();

            }

        }

        public async Task<IEnumerable<Cart>> GetAllCartsAsync()
        {
          return  await _trendyolContext.Carts.Include(c => c.User).Include(c => c.CartItems).ToListAsync();       
        }

        public async Task<Cart> GetCartByIdAsync(int id)
        {
            return await _trendyolContext.Carts.Include(c => c.User).Include(c => c.CartItems).FirstOrDefaultAsync(c=>c.Id==id);    
        }

        public async Task UpdateCartAsync(Cart cart)
        {
            _trendyolContext.Carts.Update(cart);
            await _trendyolContext.SaveChangesAsync();
        }
    }
}
