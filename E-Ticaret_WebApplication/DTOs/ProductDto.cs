using E_Ticaret_WebApplication.Models;

namespace E_Ticaret_WebApplication.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        // İlişki
        public int CategoryId { get; set; }
       
    }
}
