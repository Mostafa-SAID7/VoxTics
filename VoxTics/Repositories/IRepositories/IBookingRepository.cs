using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories;

namespace VoxTics.Repositories.IRepositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        // Booking-specific queries
        Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId);
        Task<Booking?> GetBookingWithDetailsAsync(int bookingId);
        Task<IEnumerable<Booking>> GetBookingsByStatusAsync(BookingStatus status);
        Task<IEnumerable<Booking>> GetBookingsByShowtimeAsync(int showtimeId);
        Task<IEnumerable<Booking>> GetBookingsByMovieAsync(int movieId);
        Task<IEnumerable<Booking>> GetBookingsByCinemaAsync(int cinemaId);

        // Booking Seats
        Task<IEnumerable<BookingSeat>> GetBookingSeatsAsync(int bookingId);
        Task<IEnumerable<Seat>> GetBookedSeatsAsync(int showtimeId);
        Task<IEnumerable<Seat>> GetAvailableSeatsAsync(int showtimeId);
        Task<bool> AreSeatsAvailableAsync(int showtimeId, IEnumerable<int> seatIds);

        // Date-based queries
        Task<IEnumerable<Booking>> GetBookingsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Booking>> GetTodaysBookingsAsync();
        Task<IEnumerable<Booking>> GetUpcomingBookingsAsync(int userId);
        Task<IEnumerable<Booking>> GetPastBookingsAsync(int userId);

        // Search and Filter
        Task<IEnumerable<Booking>> SearchBookingsAsync(string searchTerm);
        Task<(IEnumerable<Booking> bookings, int totalCount)> GetPagedBookingsAsync(BasePaginatedFilterVM filter);
        Task<(IEnumerable<Booking> bookings, int totalCount)> GetPagedUserBookingsAsync(int userId, BasePaginatedFilterVM filter);

        // Statistics
        Task<decimal> GetTotalRevenueAsync();
        Task<decimal> GetRevenueByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<decimal> GetRevenueByMovieAsync(int movieId);
        Task<decimal> GetRevenueByCinemaAsync(int cinemaId);
        Task<int> GetBookingCountByStatusAsync(BookingStatus status);
        Task<int> GetTotalTicketsSoldAsync();
        Task<Dictionary<string, int>> GetBookingStatusStatsAsync();
        Task<Dictionary<string, decimal>> GetMonthlyRevenueStatsAsync(int year);

        // Occupancy and Analytics
        Task<double> GetShowtimeOccupancyRateAsync(int showtimeId);
        Task<double> GetAverageOccupancyRateAsync();
        Task<IEnumerable<(Movie movie, int bookingCount)>> GetTopMoviesByBookingsAsync(int count = 10);
        Task<IEnumerable<(Cinema cinema, decimal revenue)>> GetTopCinemasByRevenueAsync(int count = 5);

        // Booking Management
        Task<bool> CanCancelBookingAsync(int bookingId);
        Task<bool> CancelBookingAsync(int bookingId);
        Task<bool> ConfirmBookingAsync(int bookingId);
        Task<bool> UpdateBookingStatusAsync(int bookingId, BookingStatus status);

        // Payment related
        Task<IEnumerable<Booking>> GetPendingPaymentBookingsAsync();
        Task<IEnumerable<Booking>> GetExpiredBookingsAsync();
        Task<bool> MarkPaymentCompletedAsync(int bookingId, string paymentReference);

        // Validation
        Task<bool> IsBookingNumberUniqueAsync(string bookingNumber);
        Task<bool> CanUserBookAsync(int userId, int showtimeId);
        Task<string> GenerateBookingNumberAsync();

        // Admin specific
        Task<IEnumerable<Booking>> GetBookingsForAdminAsync();
        Task<(IEnumerable<Booking> bookings, int totalCount)> GetPagedBookingsForAdminAsync(BasePaginatedFilterVM filter);
        Task<Dictionary<string, object>> GetBookingDashboardStatsAsync();
    }
}
