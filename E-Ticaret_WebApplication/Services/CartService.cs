using E_Ticaret_WebApplication.DTOs;
using E_Ticaret_WebApplication.Models;
using E_Ticaret_WebApplication.Repositories.Interfaces;

namespace E_Ticaret_WebApplication.Services
{
    public class CartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<IEnumerable<CartDto>> GetAllCartsAsync()
        {
            var carts = await _cartRepository.GetAllCartsAsync();
            return carts.Select(a => new CartDto { Id = a.Id, UserId = a.UserId });
        }

        public async Task<CartDto> GetCartByIdAsync(int id)
        {
            var cart = await _cartRepository.GetCartByIdAsync(id);
            return cart != null ? new CartDto { Id = cart.Id, UserId = cart.UserId } : null;
        }

        public async Task AddCartAsync(CartDto cartDto)
        {
            var cart = new Cart { UserId = cartDto.UserId };
            await _cartRepository.AddCartAsync(cart);
        }

        public async Task UpdateCartAsync(CartDto cartDto)
        {
            var cart = new Cart { Id = cartDto.Id, UserId = cartDto.UserId };
            await _cartRepository.UpdateCartAsync(cart);
        }

        public async Task DeleteCartAsync(int id)
        {
            await _cartRepository.DeleteCartAsync(id);
        }
    }
}
