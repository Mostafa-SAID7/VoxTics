using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels.Booking;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.IServices;

namespace VoxTics.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingsRepository _bookingsRepo;

        public BookingService(IBookingsRepository bookingsRepo)
        {
            _bookingsRepo = bookingsRepo;
        }

        public async Task<BookingDetailsVM> CreateBookingAsync(
            BookingCreateVM model,
            string userId,
            string? couponCode = null,
            CancellationToken cancellationToken = default)
        {
            return await _bookingsRepo.CreateBookingAsync(model, userId, couponCode, cancellationToken)
                                      .ConfigureAwait(false);
        }

        public async Task<BookingDetailsVM?> GetBookingDetailsAsync(
            string bookingReference,
            CancellationToken cancellationToken = default)
        {
            return await _bookingsRepo.GetBookingDetailsAsync(bookingReference, cancellationToken)
                                      .ConfigureAwait(false);
        }

        public async Task<bool> CancelBookingAsync(
            string bookingReference,
            string reason,
            bool issueRefund = false,
            CancellationToken cancellationToken = default)
        {
            return await _bookingsRepo.CancelBookingAsync(bookingReference, reason, issueRefund, cancellationToken)
                                      .ConfigureAwait(false);
        }

        public async Task<bool> UpdatePaymentStatusAsync(
            string bookingReference,
            PaymentStatus status,
            DateTime? paymentDate = null,
            CancellationToken cancellationToken = default)
        {
            return await _bookingsRepo.UpdatePaymentStatusAsync(bookingReference, status, paymentDate, cancellationToken)
                                      .ConfigureAwait(false);
        }

        public Task<string?> GetUserBookingsAsync(string userId, int page, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
