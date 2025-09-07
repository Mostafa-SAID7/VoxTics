using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.ViewModels
{
    public class CinemaVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        // Description & Location
        public string? Description { get; set; }
        public string Location { get; set; } = string.Empty;

        // Contact info
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string PhoneNumber => Phone ?? string.Empty;

        [NotMapped]
        public string? Website { get; set; }

        // Social media links
        public List<SocialMediaLinkVM> SocialMediaLinks { get; set; } = new List<SocialMediaLinkVM>();

        // Images
        public string? ImageUrl { get; set; }
        public bool HasImage => !string.IsNullOrEmpty(ImageUrl);
        public string DefaultImage => "/images/default-cinema.jpg";
        public string DisplayImage => HasImage ? ImageUrl! : DefaultImage;

        // Halls & Showtimes
        public int HallCount { get; set; }
        public List<ShowtimeVM> Showtimes { get; set; } = new List<ShowtimeVM>();
        // Computed helpers
        public int TotalSeats { get; set; }

        public int SeatCount { get; set; }
        public string HallSummary => HallCount == 1 ? "1 Hall" : $"{HallCount} Halls";
        public bool HasShowtimes => Showtimes.Any();
    }
}
