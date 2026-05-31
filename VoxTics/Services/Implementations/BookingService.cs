using AutoMapper;
using VoxTics.Data.UoW;
using VoxTics.Models.Entities;
using VoxTics.Models.Enums;
using VoxTics.Models.ViewModels.Booking;
using VoxTics.Services.Interfaces;
using VoxTics.Services.IServices;

namespace VoxTics.Services
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public BookingService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingListVM>> GetUserBookingsAsync(string userId)
        {
            var bookings = await _uow.Bookings.GetUserBookingsAsync(userId);
            return _mapper.Map<IEnumerable<BookingListVM>>(bookings);
        }

        public async Task<BookingDetailsVM?> GetBookingDetailsAsync(int bookingId, string userId)
        {
            var booking = await _uow.Bookings.GetBookingDetailsAsync(bookingId, userId);
            return booking == null ? null : _mapper.Map<BookingDetailsVM>(booking);
        }

        public async Task<BookingDetailsVM> CreateBookingAsync(BookingCreateVM model, string userId)
        {
            var booking = new Booking
            {
                UserId         = userId,
                ShowtimeId     = model.ShowtimeId,
                NumberOfTickets = model.SeatIds.Count,
                TotalAmount    = model.TotalAmount,
                DiscountAmount = model.DiscountAmount,
                FinalAmount    = model.FinalAmount,
                Status         = BookingStatus.Confirmed,
                BookingSeats   = model.SeatIds.Select(seatId => new BookingSeat
                {
                    SeatId    = seatId,
                    SeatPrice = model.SeatPrice
                }).ToList()
            };

            await _uow.Bookings.AddAsync(booking);

            // Decrement available seats on the showtime
            await _uow.Showtimes.ReserveSeatAsync(model.ShowtimeId, model.SeatIds.Count);

            await _uow.CommitAsync();

            // Re-fetch with full navigation for the confirmation view
            var saved = await _uow.Bookings.GetBookingDetailsAsync(booking.Id);
            return _mapper.Map<BookingDetailsVM>(saved ?? booking);
        }

        public async Task<bool> CancelBookingAsync(int bookingId, string userId)
        {
            var booking = await _uow.Bookings.GetBookingDetailsAsync(bookingId, userId);
            if (booking == null || !booking.CanBeCancelled) return false;

            booking.Status = BookingStatus.Cancelled;
            await _uow.Bookings.UpdateAsync(booking);

            // Release the seats back
            await _uow.Showtimes.ReleaseSeatsAsync(booking.ShowtimeId, booking.NumberOfTickets);

            await _uow.CommitAsync();
            return true;
        }

        public async Task<bool> CheckInBookingAsync(int bookingId, string userId)
        {
            var booking = await _uow.Bookings.GetBookingDetailsAsync(bookingId, userId);
            if (booking == null || booking.IsCheckedIn) return false;

            booking.IsCheckedIn = true;
            booking.Status      = BookingStatus.Completed;
            await _uow.Bookings.UpdateAsync(booking);
            await _uow.CommitAsync();
            return true;
        }
    }
}
