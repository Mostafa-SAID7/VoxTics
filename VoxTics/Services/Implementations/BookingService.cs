using VoxTics.Data.UoW;
using VoxTics.Services.Interfaces;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _unitOfWork.Bookings.GetAllAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByUserAsync(string userId)
        {
            return await _unitOfWork.Bookings.GetBookingsByUserIdAsync(userId);
        }

        public async Task<Booking?> GetBookingByIdAsync(int id)
        {
            return await _unitOfWork.Bookings.GetByIdAsync(id);
        }

        public async Task CreateBookingAsync(Booking booking, string userId)
        {
            await _unitOfWork.Bookings.AddAsync(booking);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateBookingAsync(Booking booking, string userId)
        {
        
            _unitOfWork.Bookings.Update(booking); // ✅ Update added to repo
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteBookingAsync(int id, string userId)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(id);
            if (booking == null)
                throw new UnauthorizedAccessException("Cannot delete another user's booking.");

            _unitOfWork.Bookings.Remove(booking); // ✅ Uses repo.Remove
            await _unitOfWork.CompleteAsync();
        }
    }
}
