namespace E_Ticaret_WebApplication.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        // İlişki
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
