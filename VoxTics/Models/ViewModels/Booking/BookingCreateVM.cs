using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.ViewModels.Booking
{
    /// <summary>
    /// Input model for creating a booking.
    /// </summary>
    public class BookingCreateVM
    {
        [Required]
        public int ShowtimeId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "At least one seat must be selected.")]
        public List<int> SelectedSeatIds { get; set; } = new();

        public string? CouponCode { get; set; }
    }
}
