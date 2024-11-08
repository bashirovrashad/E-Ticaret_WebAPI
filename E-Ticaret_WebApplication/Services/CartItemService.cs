using E_Ticaret_WebApplication.DTOs;
using E_Ticaret_WebApplication.Models;
using E_Ticaret_WebApplication.Repositories.Interfaces;

namespace E_Ticaret_WebApplication.Services
{
    public class CartItemService
    {
        private readonly ICartItemRepository _cartitemRepository;

        public CartItemService(ICartItemRepository cartitemRepository)
        {
            _cartitemRepository = cartitemRepository;
        }

        public async Task<IEnumerable<CartItemDto>> GetAllCartItemsAsync()
        {
            var cartitems = await _cartitemRepository.GetAllCartItemsAsync();
            return cartitems.Select(a => new CartItemDto { Id = a.Id, ProductId = a.ProductId, Quantity=a.Quantity, CartId=a.CartId  });
        }

        public async Task<CartItemDto> GetCartItemByIdAsync(int id)
        {
            var cartitem = await _cartitemRepository.GetCartItemByIdAsync(id);
            return cartitem != null ? new CartItemDto { Id = cartitem.Id, ProductId = cartitem.ProductId, Quantity= cartitem.Quantity,CartId=cartitem.CartId } : null;
        }

        public async Task AddCartItemAsync(CartItemDto cartItemDto)
        {
            var cartitem = new CartItem { ProductId = cartItemDto.ProductId, Quantity = cartItemDto.Quantity, CartId = cartItemDto.CartId };
            await _cartitemRepository.AddCartItemAsync(cartitem);
        }

        public async Task UpdateCartItemAsync(CartItemDto cartItemDto)
        {
            var cartitem = new CartItem { Id = cartItemDto.Id, ProductId = cartItemDto.ProductId, Quantity = cartItemDto.Quantity, CartId = cartItemDto.CartId };
            await _cartitemRepository.UpdateCartItemAsync(cartitem);
        }

        public async Task DeleteCartItemAsync(int id)
        {
            await _cartitemRepository.DeleteCartItemAsync(id);
        }
    }
}
