namespace E_Ticaret_WebApplication.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // İlişki
        public ICollection<Product> Products { get; set; }
    }

}
