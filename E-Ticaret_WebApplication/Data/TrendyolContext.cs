using E_Ticaret_WebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Ticaret_WebApplication.Data
{
    public class TrendyolContext:DbContext
    {
        public TrendyolContext(DbContextOptions<TrendyolContext> options) : base(options) { }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; } 


    }
}
