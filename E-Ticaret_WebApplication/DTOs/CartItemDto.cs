using E_Ticaret_WebApplication.Models;

namespace E_Ticaret_WebApplication.DTOs
{
    public class CartItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        // İlişki
        public int CartId { get; set; }

    }
}
