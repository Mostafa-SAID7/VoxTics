using VoxTics.Repositories.IRepositories;

namespace VoxTics.Areas.Admin.Repositories.IRepositories
{
    public interface IAdminBookingsRepository : IBaseRepository<Booking>
    {
        Task<(IEnumerable<Booking> Bookings, int TotalCount)> GetPagedBookingsAsync(
          int pageIndex,
          int pageSize,
          string? search = null,
          CancellationToken cancellationToken = default);

        /// <summary>
        /// Get booking details by id without user filtering (admin use).
        /// </summary>
        Task<Booking?> GetBookingDetailsAsync(
            int bookingId,
            CancellationToken cancellationToken = default);
    }
}