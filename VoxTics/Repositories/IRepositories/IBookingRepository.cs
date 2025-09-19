using VoxTics.Models.Entities;

namespace VoxTics.Repositories.IRepositories
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        /// <summary>
        /// Get all bookings for a specific user.
        /// </summary>
        Task<IEnumerable<Booking>> GetUserBookingsAsync(
            string userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get booking details (including seats and related entities) for a specific user.
        /// </summary>
        Task<Booking?> GetBookingDetailsAsync(
            int bookingId,
            string userId,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get booking details without filtering by user (admin or system use).
        /// </summary>
        Task<Booking?> GetBookingDetailsAsync(
            int bookingId,
            CancellationToken cancellationToken = default);
    }
}
