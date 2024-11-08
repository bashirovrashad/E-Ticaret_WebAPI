using E_Ticaret_WebApplication.DTOs;
using E_Ticaret_WebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly CartItemService _cartitemService;

        public CartItemController(CartItemService cartitemService)
        {
            _cartitemService = cartitemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartItems()
        {
            var cartitems = await _cartitemService.GetAllCartItemsAsync();
            return Ok(cartitems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartItemById(int id)
        {
            var cartitem = await _cartitemService.GetCartItemByIdAsync(id);
            return cartitem != null ? Ok(cartitem) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem([FromBody] CartItemDto cartItemDto)
        {
            await _cartitemService.AddCartItemAsync(cartItemDto);
            return CreatedAtAction(nameof(GetCartItemById), new { id = cartItemDto.Id }, cartItemDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItem(int id, [FromBody] CartItemDto cartItemDto)
        {
            if (id != cartItemDto.Id)
                return BadRequest();

            await _cartitemService.UpdateCartItemAsync(cartItemDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            await _cartitemService.DeleteCartItemAsync(id);
            return NoContent();
        }
    }
}
