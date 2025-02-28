﻿namespace E_Ticaret_WebApplication.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        // İlişki
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
