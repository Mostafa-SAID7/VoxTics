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

        Task<(int Total, int Today, decimal Revenue)> GetBookingStatsAsync(
            CancellationToken cancellationToken = default);

        Task<bool> ForceCancelBookingAsync(int bookingId, CancellationToken cancellationToken = default);
    }
}