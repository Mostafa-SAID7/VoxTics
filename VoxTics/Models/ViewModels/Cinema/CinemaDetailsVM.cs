using VoxTics.Models.ViewModels.Booking;
using VoxTics.Models.ViewModels.Filter;
using VoxTics.Models.ViewModels.Showtime;

namespace VoxTics.Models.ViewModels.Cinema
{
    public class CinemaDetailsVM
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
        public string DisplayImage { get; set; } = "/images/default-cinema.jpg";
        public bool IsActive { get; set; }

        // Related entities
        public IReadOnlyList<HallVM> Halls { get; set; } = new List<HallVM>();
        public IReadOnlyList<ShowtimeVM> Showtimes { get; set; } = new List<ShowtimeVM>();
        public IReadOnlyList<BookingVM> Bookings { get; set; } = new List<BookingVM>();
        public IReadOnlyList<SocialMediaLinkVM> SocialMediaLinks { get; set; } = new List<SocialMediaLinkVM>();

        // Computed properties
        public int HallCount => Halls.Count;
        public int TotalSeats => Halls.Sum(h => h.SeatCount);
        public int ShowtimeCount => Showtimes.Count;
    }
}
