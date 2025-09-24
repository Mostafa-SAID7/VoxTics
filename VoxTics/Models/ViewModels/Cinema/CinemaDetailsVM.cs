using VoxTics.Models.ViewModels.Booking;
using VoxTics.Models.ViewModels.Filter;
using VoxTics.Models.ViewModels.Showtime;

namespace VoxTics.Models.ViewModels.Cinema
{
    public class CinemaDetailsVM
    {
        // --- Basic Info ---
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
        public string DisplayImage { get; set; } 

        // --- Related Entities ---
        public IReadOnlyList<HallVM> Halls { get; set; } = new List<HallVM>();
        public IReadOnlyList<ShowtimeVM> Showtimes { get; set; } = new List<ShowtimeVM>();
        public IReadOnlyList<BookingDetailsVM> Bookings { get; set; } = new List<BookingDetailsVM>();
        public IReadOnlyList<SocialMediaLinkVM> SocialMediaLinks { get; set; } = new List<SocialMediaLinkVM>();

        // --- Computed Properties ---
        public int HallCount => Halls.Count;
        public int TotalSeats => Halls.Sum(h => h.SeatCount);
        public int ShowtimeCount => Showtimes.Count;
        public bool HasBookings => Bookings.Any();
        public bool HasShowtimes => Showtimes.Any();
        public bool HasHalls => Halls.Any();
    }
}
