using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Admin.ViewModels.Showtime
{
    public class ShowtimeViewModel
    {
        public int Id { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public string HallName { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Price { get; set; }
        public bool Is3D { get; set; }
        public string ScreenType { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public ShowtimeStatus Status { get; set; }

        // Computed
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }

        // List of bookings
        public ICollection<string> BookedUsers { get; set; } = new List<string>();

        public string StatusBadge => Status switch
        {
            ShowtimeStatus.Scheduled => "badge bg-info",
            ShowtimeStatus.Active => "badge bg-success",
            ShowtimeStatus.Cancelled => "badge bg-danger",
            _ => "badge bg-secondary"
        };

        public string StartTimeFormatted => StartTime.ToString("yyyy-MM-dd HH:mm");
        public string EndTimeFormatted => EndTime.ToString("yyyy-MM-dd HH:mm");

    }
}
