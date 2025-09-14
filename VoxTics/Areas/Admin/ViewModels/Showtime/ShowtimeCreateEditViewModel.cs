using System;
using System.ComponentModel.DataAnnotations;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels.Showtime
{
    public class ShowtimeCreateEditViewModel
    {
        public int Id { get; set; } // For edit scenarios

        [Required(ErrorMessage = "Movie selection is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid movie selection")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Hall selection is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid hall selection")]
        public int HallId { get; set; }

        [Required(ErrorMessage = "Cinema selection is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Invalid cinema selection")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Start time is required")]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; } = DateTime.Now.AddHours(1); // Default to 1 hour from now

        [Required(ErrorMessage = "Duration is required")]
        [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes")]
        public int Duration { get; set; } = 120; // Default 2 hours

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 10000, ErrorMessage = "Price must be positive and less than 10,000")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; } = 0;

        public bool Is3D { get; set; } = false;

        [Required(ErrorMessage = "Language is required")]
        [StringLength(50, ErrorMessage = "Language cannot exceed 50 characters")]
        public string Language { get; set; } = "EN";

        [Required(ErrorMessage = "Screen type is required")]
        [StringLength(50, ErrorMessage = "Screen type cannot exceed 50 characters")]
        public string ScreenType { get; set; } = "Standard";

        [Required(ErrorMessage = "Status is required")]
        public ShowtimeStatus Status { get; set; } = ShowtimeStatus.Scheduled;

        // Computed properties (optional for admin form)
        public DateTime EndTime => StartTime.AddMinutes(Duration);

        public string StartTimeFormatted => StartTime.ToString("yyyy-MM-dd HH:mm");
        public string EndTimeFormatted => EndTime.ToString("yyyy-MM-dd HH:mm");
    }
}
