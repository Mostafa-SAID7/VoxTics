using VoxTics.Data.UoW;
using VoxTics.Services.Interfaces;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _uow;
        public BookingService(IUnitOfWork uow) => _uow = uow;

        public async Task<IEnumerable<Booking>> GetAllAsync() => await _uow.Bookings.GetAllWithDetailsAsync();
        public async Task<Booking?> GetByIdAsync(int id) => await _uow.Bookings.GetByIdWithDetailsAsync(id);

        public async Task CreateAsync(Booking booking)
        {
            await _uow.Bookings.AddAsync(booking);
            await _uow.SaveAsync();
        }

        public async Task UpdateAsync(Booking booking)
        {
            _uow.Bookings.Update(booking);
            await _uow.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var booking = await _uow.Bookings.GetByIdAsync(id);
            if (booking == null) return;
            _uow.Bookings.DeleteAsync(booking);
            await _uow.SaveAsync();
        }

        public async Task UpdateStatusAsync(int id, BookingStatus status)
        {
            var booking = await _uow.Bookings.GetByIdAsync(id);
            if (booking == null) return;
            booking.Status = status;
            await _uow.SaveAsync();
        }

        public async Task CancelAsync(int id, string reason)
        {
            var booking = await _uow.Bookings.GetByIdAsync(id);
            if (booking == null) return;
            booking.Status = BookingStatus.Cancelled;
            booking.CancellationReason = reason;
            booking.CancellationDate = DateTime.UtcNow;
            await _uow.SaveAsync();
        }
    }
}
