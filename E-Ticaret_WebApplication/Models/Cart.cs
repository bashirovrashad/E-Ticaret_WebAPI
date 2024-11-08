namespace E_Ticaret_WebApplication.Models
{
    public class Cart
    {
        public int Id { get; set; }

        // İlişki
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
