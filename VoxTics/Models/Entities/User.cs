namespace VoxTics.Models.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //  Navigation property
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
