using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.ViewModels.Booking;

namespace VoxTics.Services.Interfaces
{
    /// <summary>
    /// Service contract for handling user-facing booking operations.
    /// Abstracts business logic away from controllers and repositories.
    /// </summary>
    public interface IBookingsService
    {
        /// <summary>
        /// Retrieves paginated bookings for a specific user with optional sorting.
        /// </summary>
        Task<PaginatedList<Booking>> GetUserBookingsAsync(
            string userId,
            int pageIndex,
            int pageSize,
            string? sortOrder = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves only upcoming (future) bookings for the user.
        /// </summary>
        Task<IEnumerable<Booking>> GetUpcomingBookingsAsync(
            string userId,
            DateTime currentDate,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Books a new seat for a user and validates business rules (e.g., availability).
        /// </summary>
        Task<Booking> CreateBookingAsync(
            string userId,
            int showtimeId,
            IEnumerable<string> seatNumbers,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels a booking if allowed (e.g., before showtime start).
        /// </summary>
        Task<bool> CancelBookingAsync(
            int bookingId,
            string userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Marks a booking as checked-in (e.g., QR scan at cinema).
        /// </summary>
        Task<bool> CheckInBookingAsync(
            int bookingId,
            string userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Checks whether a specific seat is already booked for a showtime.
        /// </summary>
        Task<bool> IsSeatBookedAsync(
            int showtimeId,
            string seatNumber,
            CancellationToken cancellationToken = default);
    }
}
