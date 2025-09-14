using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Data.UoW;
using VoxTics.Models.ViewModels.Booking;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces;
using VoxTics.Helpers;

namespace VoxTics.Services.Implementations
{
    /// <summary>
    /// Concrete implementation of IBookingsService.
    /// Handles user-facing booking operations and enforces domain rules.
    /// </summary>
    public class BookingsService : IBookingsService
    {
        private readonly IBookingsRepository _bookingsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookingsService(IBookingsRepository bookingsRepository, IUnitOfWork unitOfWork)
        {
            _bookingsRepository = bookingsRepository ?? throw new ArgumentNullException(nameof(bookingsRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<PaginatedList<Booking>> GetUserBookingsAsync(
            string userId,
            int pageIndex,
            int pageSize,
            string? sortOrder = null,
            CancellationToken cancellationToken = default)
        {
            var query = _bookingsRepository.Query()
                .Where(b => b.UserId == userId);

            query = query.ApplySorting(sortOrder, b => b.BookingDate); // QueryableExtensions

            var count = await _bookingsRepository.CountAsync(b => b.UserId == userId, cancellationToken)
                                                 .ConfigureAwait(false);

            var items = await query.Skip((pageIndex - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsyncSafe(cancellationToken); // ToListAsyncSafe is a pattern from QueryableExtensions

            return new PaginatedList<Booking>(items, count, pageIndex, pageSize);
        }

        public async Task<IEnumerable<Booking>> GetUpcomingBookingsAsync(
            string userId,
            DateTime currentDate,
            CancellationToken cancellationToken = default) =>
            await _bookingsRepository.GetUpcomingBookingsForUserAsync(userId, currentDate, cancellationToken)
                                     .ConfigureAwait(false);

        public async Task<Booking> CreateBookingAsync(
            string userId,
            int showtimeId,
            IEnumerable<string> seatNumbers,
            CancellationToken cancellationToken = default)
        {
            if (seatNumbers == null || !seatNumbers.Any())
                throw new ArgumentException("At least one seat must be selected.", nameof(seatNumbers));

            foreach (var seat in seatNumbers)
            {
                ValidationHelpers.ValidateSeatNumber(seat); // existing helper
                var isBooked = await _bookingsRepository.IsSeatBookedAsync(showtimeId, seat, cancellationToken)
                                                         .ConfigureAwait(false);
                if (isBooked)
                    throw new InvalidOperationException($"Seat {seat} is already booked.");
            }

            BookingRulesHelper.EnsureBookingLimit(seatNumbers); // NEW helper

            var booking = new Booking
            {
                UserId = userId,
                ShowtimeId = showtimeId,
                Seats = string.Join(",", seatNumbers),
                BookingDate = DateTimeExtensions.UtcNowSafe() // existing helper for UTC
            };

            await _bookingsRepository.AddAsync(booking, cancellationToken).ConfigureAwait(false);
            await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);

            return booking;
        }

        public async Task<bool> CancelBookingAsync(
            int bookingId,
            string userId,
            CancellationToken cancellationToken = default)
        {
            var booking = await _bookingsRepository.GetFirstOrDefaultAsync(
                b => b.Id == bookingId && b.UserId == userId, cancellationToken).ConfigureAwait(false);

            if (booking == null) return false;

            if (!BookingRulesHelper.CanCancel(booking)) return false;

            await _bookingsRepository.RemoveAsync(booking, cancellationToken).ConfigureAwait(false);
            await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
            return true;
        }

        public async Task<bool> CheckInBookingAsync(
            int bookingId,
            string userId,
            CancellationToken cancellationToken = default)
        {
            var booking = await _bookingsRepository.GetFirstOrDefaultAsync(
                b => b.Id == bookingId && b.UserId == userId, cancellationToken).ConfigureAwait(false);

            if (booking == null) return false;

            booking.IsCheckedIn = true;
            await _bookingsRepository.UpdateAsync(booking, cancellationToken).ConfigureAwait(false);
            await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
            return true;
        }

        public Task<bool> IsSeatBookedAsync(
            int showtimeId,
            string seatNumber,
            CancellationToken cancellationToken = default) =>
            _bookingsRepository.IsSeatBookedAsync(showtimeId, seatNumber, cancellationToken);
    }
}
