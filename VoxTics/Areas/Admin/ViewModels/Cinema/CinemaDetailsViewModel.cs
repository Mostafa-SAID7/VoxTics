namespace VoxTics.Areas.Admin.ViewModels.Cinema
{
    public class CinemaDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public string? Website { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }

        // Navigation collections (display names)
        public ICollection<string> Halls { get; set; } = new List<string>();
        public ICollection<string> Showtimes { get; set; } = new List<string>();
        public ICollection<string> SocialMediaLinks { get; set; } = new List<string>();

        // Computed properties
        public int TotalSeats { get; set; }
        public int HallCount { get; set; }
        public int ShowtimeCount { get; set; }

        public string StatusBadge => IsActive ? "badge bg-success" : "badge bg-secondary";
        public string DisplayImage => !string.IsNullOrEmpty(ImageUrl) ? ImageUrl : "/images/default-cinema.jpg";
    }
}
