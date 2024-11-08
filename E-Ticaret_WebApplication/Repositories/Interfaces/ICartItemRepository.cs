using E_Ticaret_WebApplication.Models;

namespace E_Ticaret_WebApplication.Repositories.Interfaces
{
    public interface ICartItemRepository
    {
        Task<IEnumerable<CartItem>> GetAllCartItemsAsync();
        Task<CartItem> GetCartItemByIdAsync(int id);
        Task AddCartItemAsync(CartItem cart);
        Task UpdateCartItemAsync(CartItem cart);
        Task DeleteCartItemAsync(int id);
    }
}
