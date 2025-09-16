using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Booking;

namespace VoxTics.Repositories.IRepositories
{
    /// <summary>
    /// Advanced repository interface for managing cinema bookings.
    /// Provides transactional operations, validation, analytics, and reporting.
    /// </summary>
    public interface IBookingsRepository : IBaseRepository<Booking>
    {
        #region Booking Creation & Validation

        /// <summary>
        /// Validates seat availability before creating a booking.
        /// </summary>
        Task<bool> AreSeatsAvailableAsync(
            int showtimeId,
            IEnumerable<int> seatIds,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Calculates the price including discounts, promotions, and taxes.
        /// </summary>
        Task<decimal> CalculateTotalPriceAsync(
            int showtimeId,
            int numberOfTickets,
            string? couponCode = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new booking transactionally.
        /// </summary>
        Task<BookingDetailsVM> CreateBookingAsync(
            BookingCreateVM model,
            string userId,
            string? couponCode = null,
            CancellationToken cancellationToken = default);

        #endregion

        #region Retrieval

        /// <summary>
        /// Gets a paginated list of a user's bookings with search & sorting.
        /// </summary>
        Task<PaginatedList<BookingSummaryVM>> GetUserBookingsAsync(
            string userId,
            int pageIndex,
            int pageSize,
            string? search = null,
            string? sortColumn = "ShowTime",
            bool sortDescending = false,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets detailed booking info by reference for user or admin.
        /// </summary>
        Task<BookingDetailsVM?> GetBookingDetailsAsync(
            string bookingReference,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets upcoming bookings for dashboard display.
        /// </summary>
        Task<List<BookingSummaryVM>> GetUpcomingBookingsAsync(
            int count = 10,
            CancellationToken cancellationToken = default);

        #endregion

        #region Status Management

        /// <summary>
        /// Cancels a booking and processes refund logic if applicable.
        /// </summary>
        Task<bool> CancelBookingAsync(
            string bookingReference,
            string reason,
            bool issueRefund = false,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the payment status of a booking.
        /// </summary>
        Task<bool> UpdatePaymentStatusAsync(
            string bookingReference,
            PaymentStatus status,
            DateTime? paymentDate = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Marks expired/unpaid bookings as void and releases seats.
        /// </summary>
        Task<int> AutoExpirePendingBookingsAsync(
            TimeSpan gracePeriod,
            CancellationToken cancellationToken = default);

        #endregion

        #region Analytics & Reporting

        /// <summary>
        /// Gets the total revenue for a date range.
        /// </summary>
        Task<decimal> GetRevenueAsync(
            DateTime startDate,
            DateTime endDate,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the most popular movies based on bookings.
        /// </summary>
        Task<List<(string MovieTitle, int TicketsSold)>> GetTopMoviesAsync(
            int count,
            DateTime? from = null,
            DateTime? to = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets booking trends for reporting dashboards.
        /// </summary>
        Task<Dictionary<DateTime, int>> GetBookingTrendsAsync(
            DateTime from,
            DateTime to,
            CancellationToken cancellationToken = default);

        #endregion

        #region Utility

        /// <summary>
        /// Checks whether a booking exists.
        /// </summary>
        Task<bool> ExistsAsync(
            string bookingReference,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets all seat numbers associated with a booking.
        /// </summary>
        Task<List<string>> GetBookingSeatsAsync(
            string bookingReference,
            CancellationToken cancellationToken = default);

        #endregion
    }
}
