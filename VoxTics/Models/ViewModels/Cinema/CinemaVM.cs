using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using VoxTics.Models.ViewModels.Showtime;

namespace VoxTics.Models.ViewModels.Cinema
{
    public class CinemaVM
    {
        public int Id { get; set; }              // Cinema Id
        public string Name { get; set; } = string.Empty;  // Cinema Name
        public string? Country { get; set; }     // Country (optional)
        public string DisplayImage { get; set; } = "/images/defaults/placeholder.jpg"; // Fallback image

        // Optional: minimal related info for list previews
        public int HallCount { get; set; } = 0;
        public int ShowtimeCount { get; set; } = 0;
    }
}
