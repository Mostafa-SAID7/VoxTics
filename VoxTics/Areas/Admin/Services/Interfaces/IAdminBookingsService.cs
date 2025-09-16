using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Models.Entities;

namespace VoxTics.Services.Interfaces
{
    public interface IAdminBookingService
    {
        Task<(IEnumerable<Booking> Bookings, int TotalCount)> GetPagedBookingsAsync(
            int pageIndex,
            int pageSize,
            string? search = null,
            CancellationToken cancellationToken = default);

        Task<(int Total, int Today, decimal Revenue)> GetBookingStatsAsync(CancellationToken cancellationToken = default);

        Task<bool> ForceCancelBookingAsync(int bookingId, CancellationToken cancellationToken = default);
    }
}
