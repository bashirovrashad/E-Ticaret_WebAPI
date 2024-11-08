namespace E_Ticaret_WebApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        // İlişki
        public Cart Cart { get; set; }
    }
}
