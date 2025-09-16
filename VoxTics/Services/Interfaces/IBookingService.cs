using VoxTics.Models.ViewModels.Booking;
using VoxTics.Models.Enums;

namespace VoxTics.Services.IServices
{
    public interface IBookingService
    {
        Task<BookingDetailsVM> CreateBookingAsync(BookingCreateVM model, string userId, string? couponCode = null, CancellationToken cancellationToken = default);
        Task<BookingDetailsVM?> GetBookingDetailsAsync(string bookingReference, CancellationToken cancellationToken = default);
        Task<bool> CancelBookingAsync(string bookingReference, string reason, bool issueRefund = false, CancellationToken cancellationToken = default);
        Task<bool> UpdatePaymentStatusAsync(string bookingReference, PaymentStatus status, DateTime? paymentDate = null, CancellationToken cancellationToken = default);
        Task<string?> GetUserBookingsAsync(string userId, int page, int pageSize, CancellationToken cancellationToken);
    }
}
