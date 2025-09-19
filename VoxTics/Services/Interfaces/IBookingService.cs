using VoxTics.Models.ViewModels.Booking;
using VoxTics.Models.Enums;

namespace VoxTics.Services.IServices
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingListVM>> GetUserBookingsAsync(string userId);
        Task<BookingDetailsVM?> GetBookingDetailsAsync(int bookingId, string userId);
        Task<BookingDetailsVM> CreateBookingAsync(BookingCreateVM model, string userId);
        Task<bool> CancelBookingAsync(int bookingId, string userId);
        Task<bool> CheckInBookingAsync(int bookingId, string userId);
    }
}
