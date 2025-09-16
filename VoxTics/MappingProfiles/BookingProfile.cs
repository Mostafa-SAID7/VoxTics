using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Booking;

namespace VoxTics.Helpers
{
    public static class BookingMappings
    {
        public static BookingDetailsVM ToDetailsVM(this Booking booking, string cinemaName, string hallName, List<string> seatNumbers)
        {
            return new BookingDetailsVM
            {
                BookingReference = booking.BookingReference,
                MovieTitle = booking.Showtime.Movie.Title,
                CinemaName = cinemaName,
                HallName = hallName,
                ShowTime = booking.Showtime.StartTime,
                BookingDate = booking.BookingDate,
                NumberOfTickets = booking.NumberOfTickets,
                SeatNumbers = seatNumbers,
                TotalAmount = booking.TotalAmount,
                FinalAmount = booking.TotalAmount,
                Status = booking.Status,
                PaymentStatus = booking.PaymentStatus,
                PaymentMethod = booking.PaymentMethod
            };
        }

        public static BookingSummaryVM ToSummaryVM(this Booking booking, string cinemaName, string hallName)
        {
            return new BookingSummaryVM
            {
                BookingReference = booking.BookingReference,
                MovieTitle = booking.Showtime.Movie.Title,
                CinemaName = cinemaName,
                HallName = hallName,
                ShowTime = booking.Showtime.StartTime,
                NumberOfTickets = booking.NumberOfTickets,
                TotalAmount = booking.TotalAmount,
                DiscountAmount = 0,
                FinalAmount = booking.TotalAmount,
                PaymentMethod = booking.PaymentMethod,
                Status = booking.Status.ToString(),
                CanBeCancelled = booking.Showtime.StartTime > DateTime.UtcNow,
                SavingsAmount = 0,
                SeatNumbers = new List<string>() // populated separately if needed
            };
        }
    }
}
