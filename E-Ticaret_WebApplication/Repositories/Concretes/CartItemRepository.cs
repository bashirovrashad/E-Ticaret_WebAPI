using E_Ticaret_WebApplication.Data;
using E_Ticaret_WebApplication.Models;
using E_Ticaret_WebApplication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret_WebApplication.Repositories.Concretes
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly TrendyolContext _trendyolContext;
        public CartItemRepository(TrendyolContext context)
        {
            _trendyolContext = context;
        }
        public async Task AddCartItemAsync(CartItem cartitem)
        {
            _trendyolContext.CartItems.Add(cartitem);
            await _trendyolContext.SaveChangesAsync();
        }

        public async Task DeleteCartItemAsync(int id)
        {
            var cartitem = await _trendyolContext.CartItems.FindAsync(id);
            if (cartitem != null)
            {
                _trendyolContext.CartItems.Remove(cartitem);
                await _trendyolContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CartItem>> GetAllCartItemsAsync()
        {
          return await _trendyolContext.CartItems.Include(c=>c.Cart).Include(c=>c.Product).ToListAsync(); 
        }

        public async Task<CartItem> GetCartItemByIdAsync(int id)
        {
            return await _trendyolContext.CartItems.Include(c => c.Cart).Include(c => c.Product).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task UpdateCartItemAsync(CartItem cartitem)
        {
            _trendyolContext.CartItems.Update(cartitem);
            await _trendyolContext.SaveChangesAsync();
        }
    }
}
