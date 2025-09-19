using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Admin.Services.Interfaces;
using VoxTics.Models.Entities;

namespace VoxTics.Areas.Admin.Services.Implementations
{
    public class AdminBookingsService : IAdminBookingsService
    {
        private readonly IAdminBookingsRepository _repository;

        public AdminBookingsService(IAdminBookingsRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<(IEnumerable<Booking> Bookings, int TotalCount)> GetPagedBookingsAsync(
            int pageIndex,
            int pageSize,
            string? search = null,
            CancellationToken cancellationToken = default)
        {
            return await _repository.GetPagedBookingsAsync(pageIndex, pageSize, search, cancellationToken);
        }

        public async Task<Booking?> GetBookingDetailsAsync(int bookingId, CancellationToken cancellationToken = default)
        {
            return await _repository.GetBookingDetailsAsync(bookingId, cancellationToken);
        }
    }
}
