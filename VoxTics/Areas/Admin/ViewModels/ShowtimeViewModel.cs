using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Admin.ViewModels
{
    public class ShowtimeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie is required")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Cinema is required")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "Hall is required")]
        [Display(Name = "Hall")]
        public int HallId { get; set; }

        [Required(ErrorMessage = "Show date and time is required")]
        [Display(Name = "Show Date & Time")]
        public DateTime ShowDateTime { get; set; } = DateTime.Now.AddDays(1);

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 100, ErrorMessage = "Price must be between 0.01 and 100")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        // Navigation properties for display
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public string HallName { get; set; } = string.Empty;
        public int TotalSeats { get; set; }
        public int BookedSeats { get; set; }
        public int AvailableSeats => TotalSeats - BookedSeats;

        // Dropdown lists
        public List<SelectListItem> Movies { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Cinemas { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Halls { get; set; } = new List<SelectListItem>();

        // Display properties
        public string ShowDateFormatted => ShowDateTime.ToString("MMM dd, yyyy");
        public string ShowTimeFormatted => ShowDateTime.ToString("hh:mm tt");
        public string ShowDateTimeFormatted => ShowDateTime.ToString("MMM dd, yyyy hh:mm tt");
        public string FormattedPrice => Price.ToString("C");
        [Range(0, int.MaxValue, ErrorMessage = "Available seats cannot be negative")]
        [Display(Name = "Available Seats")]
        public bool IsAvailable => AvailableSeats > 0;
        public bool IsPastShow => ShowDateTime < DateTime.Now;

        public string StatusBadge => IsPastShow ? "badge bg-secondary" :
                                   IsAvailable ? "badge bg-success" : "badge bg-danger";
        public string StatusText => IsPastShow ? "Ended" :
                                  IsAvailable ? "Available" : "Sold Out";

        [Required(ErrorMessage = "Start time is required")]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "End time is required")]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        

       

        [Required(ErrorMessage = "Status is required")]
        [Display(Name = "Status")]
        public ShowtimeStatus Status { get; set; }


        

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


        public int BookingCount { get; set; }
        public bool IsExpired { get; set; }
        public bool IsUpcoming { get; set; }
        public bool IsOngoing { get; set; }

    }
}
