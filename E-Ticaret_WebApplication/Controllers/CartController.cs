using E_Ticaret_WebApplication.DTOs;
using E_Ticaret_WebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_Ticaret_WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarts()
        {
            var carts = await _cartService.GetAllCartsAsync();
            return Ok(carts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartById(int id)
        {
            var cart = await _cartService.GetCartByIdAsync(id);
            return cart != null ? Ok(cart) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddCart([FromBody] CartDto cartDto)
        {
            await _cartService.AddCartAsync(cartDto);
            return CreatedAtAction(nameof(GetCartById), new { id = cartDto.Id }, cartDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(int id, [FromBody] CartDto cartDto)
        {
            if (id != cartDto.Id)
                return BadRequest();

            await _cartService.UpdateCartAsync(cartDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            await _cartService.DeleteCartAsync(id);
            return NoContent();
        }
    }
}
