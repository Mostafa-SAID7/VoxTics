using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories.IRepositories
{
    /// <summary>
    /// Specialized repository interface for managing movie bookings.
    /// Extends IBaseRepository for standard CRUD and adds domain-specific operations.
    /// </summary>
    public interface IBookingsRepository : IBaseRepository<Booking>
    {
        #region Advanced Queries

        /// <summary>
        /// Gets all bookings for a specific user.
        /// </summary>
        /// <param name="userId">The user’s ID.</param>
        /// <param name="cancellationToken">Cancellation token for async operation.</param>
        Task<IEnumerable<Booking>> GetBookingsByUserAsync(
            string userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all bookings for a specific showtime.
        /// </summary>
        /// <param name="showtimeId">The showtime ID.</param>
        Task<IEnumerable<Booking>> GetBookingsByShowtimeAsync(
            int showtimeId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks if a seat is already booked for a showtime.
        /// </summary>
        /// <param name="showtimeId">The showtime ID.</param>
        /// <param name="seatNumber">The seat number to check.</param>
        Task<bool> IsSeatBookedAsync(
            int showtimeId,
            string seatNumber,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets upcoming bookings for a user (future showtimes only).
        /// </summary>
        Task<IEnumerable<Booking>> GetUpcomingBookingsForUserAsync(
            string userId,
            DateTime currentDate,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves paginated bookings with optional filtering.
        /// </summary>
        /// <param name="pageIndex">Zero-based page index.</param>
        /// <param name="pageSize">Number of bookings per page.</param>
        /// <param name="searchTerm">Optional filter by movie title or user.</param>
        Task<(IEnumerable<Booking> Bookings, int TotalCount)> GetPagedBookingsAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets summary statistics for bookings (e.g., total, today, this week).
        /// </summary>
        Task<(int TotalBookings, int TodayBookings, int WeeklyBookings)> GetBookingSummaryAsync(
            CancellationToken cancellationToken = default);

        #endregion

        #region Commands (Domain-Specific)

        /// <summary>
        /// Cancels a booking by its ID.
        /// </summary>
        /// <param name="bookingId">The booking ID to cancel.</param>
        /// <param name="cancellationToken">Cancellation token for async operation.</param>
        Task<bool> CancelBookingAsync(
            int bookingId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Marks a booking as checked-in.
        /// </summary>
        /// <param name="bookingId">The booking ID.</param>
        Task<bool> MarkAsCheckedInAsync(
            int bookingId,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
