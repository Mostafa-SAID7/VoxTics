using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.Services.Interfaces;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Data.UoW;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Services.Interfaces;

namespace VoxTics.Areas.Admin.Services.Implementations
{
    public class AdminBookingsService : IAdminBookingsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminBookingsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        #region Paged Bookings

        public async Task<PaginatedList<Booking>> GetPagedBookingsAsync(
            int pageIndex,
            int pageSize,
            string? searchTerm = null,
            string? sortOrder = null,
            CancellationToken cancellationToken = default)
        {
            var query = _unitOfWork.Bookings.Query()
                .Include(b => b.User)
                .Include(b => b.Movie)
                .Include(b => b.Showtime)
                .Include(b => b.Cinema)
                .AsNoTracking();

            // Optional search
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(b =>
                    b.BookingNumber.Contains(searchTerm) ||
                    b.User.Email.Contains(searchTerm) ||
                    b.Movie.Title.Contains(searchTerm));
            }

            // Apply sorting
            query = query.ApplySorting(sortOrder ?? "desc", b => b.BookingDate);

            var totalCount = await _unitOfWork.Bookings.CountAsync(cancellationToken: cancellationToken);
            var items = await query.Skip((pageIndex - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsyncSafe(cancellationToken);

            return new PaginatedList<Booking>(items, totalCount, pageIndex, pageSize);
        }

        #endregion

        #region Statistics

        public async Task<(int TotalBookings, int TodayBookings, int WeeklyBookings, decimal Revenue)> GetBookingStatsAsync(
            CancellationToken cancellationToken = default)
        {
            var allBookings = _unitOfWork.Bookings.Query();

            var total = await allBookings.CountAsync(cancellationToken);
            var today = await allBookings.CountAsync(b => b.BookingDate.Date == DateTime.UtcNow.Date, cancellationToken);
            var weekStart = DateTime.UtcNow.AddDays(-7);
            var weekly = await allBookings.CountAsync(b => b.BookingDate >= weekStart, cancellationToken);
            var revenue = await allBookings.SumAsync(b => b.FinalAmount, cancellationToken);

            return (total, today, weekly, revenue);
        }

        #endregion

        #region CRUD & Domain Actions

        public async Task<Booking> CreateBookingAsync(
            string userId,
            int showtimeId,
            IEnumerable<string> seatNumbers,
            CancellationToken cancellationToken = default)
        {
            // Validate seats
            foreach (var seat in seatNumbers)
            {
                if (!ValidationHelpers.ValidateSeatNumber(seat))
                    throw new ArgumentException($"Seat {seat} is invalid");

                if (await IsSeatBookedAsync(showtimeId, seat, cancellationToken))
                    throw new InvalidOperationException($"Seat {seat} is already booked");
            }

            var showtime = await _unitOfWork.Showtimes.GetByIdAsync(showtimeId, cancellationToken);
            if (showtime == null)
                throw new ArgumentException("Showtime not found");

            var booking = new Booking
            {
                UserId = userId,
                ShowtimeId = showtimeId,
                MovieId = showtime.MovieId,
                CinemaId = showtime.CinemaId,
                BookingNumber = Guid.NewGuid().ToString("N").Substring(0, 10).ToUpper(),
                NumberOfTickets = seatNumbers.Count(),
                Seats = string.Join(",", seatNumbers),
                TotalAmount = seatNumbers.Count() * showtime.Price,
                FinalAmount = seatNumbers.Count() * showtime.Price, // can add discounts here
                Status = BookingStatus.Confirmed,
                PaymentStatus = PaymentStatus.Pending,
                BookingDate = DateTime.UtcNow
            };

            await _unitOfWork.Bookings.AddAsync(booking, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return booking;
        }

        public async Task<bool> ForceCancelBookingAsync(int bookingId, CancellationToken cancellationToken = default)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(bookingId, cancellationToken);
            if (booking == null) return false;

            booking.Status = BookingStatus.Cancelled;
            booking.CancellationDate = DateTime.UtcNow;
            booking.CancellationReason = "Cancelled by Admin";

            await _unitOfWork.Bookings.UpdateAsync(booking, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return true;
        }

        public async Task<IEnumerable<Booking>> GetBookingsByShowtimeAsync(int showtimeId, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Bookings.FindAsync(b => b.ShowtimeId == showtimeId, cancellationToken);
        }

        public async Task<bool> IsSeatBookedAsync(int showtimeId, string seatNumber, CancellationToken cancellationToken = default)
        {
            var booked = await _unitOfWork.Bookings.Query()
                .Include(b => b.BookingSeats)
                .AnyAsync(b => b.ShowtimeId == showtimeId &&
                               b.BookingSeats.Any(bs => bs.SeatNumber == seatNumber), cancellationToken);
            return booked;
        }

        public async Task<bool> MarkAsCheckedInAsync(int bookingId, CancellationToken cancellationToken = default)
        {
            var booking = await _unitOfWork.Bookings.GetByIdAsync(bookingId, cancellationToken);
            if (booking == null) return false;

            booking.IsCheckedIn = true;
            await _unitOfWork.Bookings.UpdateAsync(booking, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Booking>> GetUpcomingBookingsForUserAsync(string userId, DateTime currentDate, CancellationToken cancellationToken = default)
        {
            return await _unitOfWork.Bookings.FindAsync(
                b => b.UserId == userId && b.Showtime.StartTime > currentDate, cancellationToken);
        }

        public Task<bool> UpdateBookingAsync(int bookingId, IEnumerable<string>? seatNumbers = null, DateTime? newShowtime = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
