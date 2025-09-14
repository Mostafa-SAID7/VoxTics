using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Helpers;
using VoxTics.Models.ViewModels.Booking;

namespace VoxTics.Services.Interfaces
{
    /// <summary>
    /// Service contract for admin-facing booking operations.
    /// Provides advanced management, reporting, and analytics for bookings.
    /// </summary>
    public interface IAdminBookingsService
    {
        /// <summary>
        /// Retrieves all bookings with pagination, filtering, and sorting.
        /// </summary>
        Task<PaginatedList<Booking>> GetPagedBookingsAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? sortOrder = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets booking statistics: total, today, weekly, revenue, etc.
        /// </summary>
        Task<(int TotalBookings, int TodayBookings, int WeeklyBookings, decimal Revenue)> GetBookingStatsAsync(
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Forcefully cancels a booking (regardless of user restrictions).
        /// </summary>
        Task<bool> ForceCancelBookingAsync(
            int bookingId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a booking on behalf of a user.
        /// </summary>
        Task<Booking> CreateBookingAsync(
            string userId,
            int showtimeId,
            IEnumerable<string> seatNumbers,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates booking details (admin can change seats, status, etc.).
        /// </summary>
        Task<bool> UpdateBookingAsync(
            int bookingId,
            IEnumerable<string>? seatNumbers = null,
            DateTime? newShowtime = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves bookings by showtime with optional filtering.
        /// </summary>
        Task<IEnumerable<Booking>> GetBookingsByShowtimeAsync(
            int showtimeId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if a seat is booked for a specific showtime.
        /// </summary>
        Task<bool> IsSeatBookedAsync(
            int showtimeId,
            string seatNumber,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Marks a booking as checked-in (QR scan or manual).
        /// </summary>
        Task<bool> MarkAsCheckedInAsync(
            int bookingId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves upcoming bookings for a specific user.
        /// </summary>
        Task<IEnumerable<Booking>> GetUpcomingBookingsForUserAsync(
            string userId,
            DateTime currentDate,
            CancellationToken cancellationToken = default);
    }
}
