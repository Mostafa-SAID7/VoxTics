using System.Globalization;
using VoxTics.Areas.Admin.ViewModels.Showtime;
using VoxTics.Areas.Identity.Models.ViewModels;

namespace VoxTics.Areas.Admin.ViewModels.Booking
{
    public class BookingDetailsViewModel
    {
        public int BookingId { get; set; }
        public string UserFullName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public DateTime Showtime { get; set; }
        public List<string> SeatNumbers { get; set; } = new List<string>();
        public decimal SeatPrice { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
    }
}
