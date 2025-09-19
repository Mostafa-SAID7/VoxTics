using VoxTics.Models.Entities;

namespace VoxTics.Areas.Admin.Services.Interfaces
{
    public interface IAdminBookingsService
    {
        /// <summary>
        /// Get paged bookings with optional search for admin dashboard.
        /// </summary>
        Task<(IEnumerable<Booking> Bookings, int TotalCount)> GetPagedBookingsAsync(
            int pageIndex,
            int pageSize,
            string? search = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Get booking details for admin (no user filtering).
        /// </summary>
        Task<Booking?> GetBookingDetailsAsync(int bookingId, CancellationToken cancellationToken = default);
    }
}
