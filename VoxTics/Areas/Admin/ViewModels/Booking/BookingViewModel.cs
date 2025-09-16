using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using VoxTics.Areas.Admin.ViewModels.Showtime;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Models.Enums;

namespace VoxTics.Areas.Admin.ViewModels.Booking
{
    public class BookingViewModel
    {
        private Models.Entities.Booking b;

        public BookingViewModel(Models.Entities.Booking b)
        {
            this.b = b;
        }

        public int Id { get; set; }
        public string BookingNumber { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public string ShowtimeDisplay { get; set; } = string.Empty;
        public int NumberOfTickets { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public BookingStatus Status { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public string? TransactionId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? Notes { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime? CancellationDate { get; set; }
        public string? CancellationReason { get; set; }

        public ICollection<string> Seats { get; set; } = new List<string>();
        public object HallName { get; internal set; }
    }
}
