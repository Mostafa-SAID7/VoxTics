using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Models.Entities;
using VoxTics.Services.Interfaces;
using VoxTics.Helpers;

namespace VoxTics.Services.Implementations
{
    public class AdminBookingService : IAdminBookingService
    {
        private readonly IAdminBookingsRepository _bookingRepository;

        public AdminBookingService(IAdminBookingsRepository bookingRepository)
        {
            _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        }

        public async Task<(IEnumerable<Booking> Bookings, int TotalCount)> GetPagedBookingsAsync(
            int pageIndex,
            int pageSize,
            string? search = null,
            CancellationToken cancellationToken = default)
        {
            var (bookings, totalCount) = await _bookingRepository
                .GetPagedBookingsAsync(pageIndex, pageSize, search, cancellationToken)
                .ConfigureAwait(false);

            return (bookings, totalCount);
        }

        public async Task<(int Total, int Today, decimal Revenue)> GetBookingStatsAsync(
            CancellationToken cancellationToken = default)
        {
            var (total, today, revenue) = await _bookingRepository
                .GetBookingStatsAsync(cancellationToken)
                .ConfigureAwait(false);

            return (total, today, revenue);
        }

        public async Task<bool> ForceCancelBookingAsync(
            int bookingId,
            CancellationToken cancellationToken = default)
        {
            var success = await _bookingRepository
                .ForceCancelBookingAsync(bookingId, cancellationToken)
                .ConfigureAwait(false);

            if (success)
            {
                // Optional: Apply business logic / trigger refund
                // e.g., BookingRulesHelper.HandleCancellation(bookingId);
            }

            return success;
        }
    }
}
