using E_Ticaret_WebApplication.Models;

namespace E_Ticaret_WebApplication.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }

        // İlişki
        public int UserId { get; set; }
    }
}
