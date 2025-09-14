namespace VoxTics.Areas.Admin.ViewModels.Cinema
{
    public class CinemaTableViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        // Display-friendly badge
        public string StatusBadge => IsActive ? "badge bg-success" : "badge bg-secondary";

        // Optional counts
        public int HallCount { get; set; }
        public int TotalSeats { get; set; }
        public int ShowtimeCount { get; set; }
    }
}
