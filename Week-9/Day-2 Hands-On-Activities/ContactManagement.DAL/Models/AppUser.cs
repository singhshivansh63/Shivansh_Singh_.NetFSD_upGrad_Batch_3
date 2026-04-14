namespace ContactManagement.DAL11.Models
{
    public class AppUser
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;   // ✅ FIX HERE

        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }
}