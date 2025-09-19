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
        public int BookingId { get; set; }
        public string UserFullName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public string MovieTitle { get; set; } = string.Empty;
        public string CinemaName { get; set; } = string.Empty;
        public DateTime Showtime { get; set; }
        public int SeatCount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
