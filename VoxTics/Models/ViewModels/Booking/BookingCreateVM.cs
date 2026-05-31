using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.ViewModels.Booking
{
    public class BookingCreateVM
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        public int CinemaId { get; set; }

        [Required]
        public int ShowtimeId { get; set; }

        [Required, MinLength(1, ErrorMessage = "At least one seat must be selected.")]
        public List<int> SeatIds { get; set; } = new();

        [Required, Range(0, double.MaxValue)]
        public decimal SeatPrice { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal TotalAmount { get; set; }

        [Range(0, double.MaxValue)]
        public decimal DiscountAmount { get; set; }

        [Required, Range(0, double.MaxValue)]
        public decimal FinalAmount { get; set; }

        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        // Display-only fields (not posted back as form fields)
        public string MovieTitle { get; set; } = string.Empty;
        public string MovieMainImage { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public string HallName { get; set; } = string.Empty;
        public DateTime ShowtimeStart { get; set; }
        public int ShowtimeDuration { get; set; }
        public int AvailableSeatsCount { get; set; }

        public List<SeatOptionVM> AvailableSeats { get; set; } = new();
    }
}
