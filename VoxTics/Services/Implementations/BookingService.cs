using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VoxTics.Data.UoW;
using VoxTics.Services.Interfaces;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Models.ViewModels.Booking;

namespace VoxTics.Services.Implementations
{
    /// <summary>
    /// Service layer for handling booking operations with AutoMapper.
    /// </summary>
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public BookingService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

   
        public async Task<IEnumerable<BookingVM>> GetAllAsync()
        {
            var bookings = await _uow.Bookings.GetAllWithDetailsAsync();
            return _mapper.Map<IEnumerable<BookingVM>>(bookings);
        }

      
        public async Task<BookingVM?> GetByIdAsync(int id)
        {
            var booking = await _uow.Bookings.GetByIdWithDetailsAsync(id);
            return booking is null ? null : _mapper.Map<BookingVM>(booking);
        }

        public async Task CreateAsync(BookingCreateVM createVM)
        {
            if (createVM == null) throw new ArgumentNullException(nameof(createVM));

            var booking = _mapper.Map<Booking>(createVM);
            booking.BookingDate = DateTime.UtcNow;
            booking.Status = BookingStatus.Pending;
            booking.PaymentStatus = PaymentStatus.Pending;

            await _uow.Bookings.AddAsync(booking);
            await _uow.SaveAsync();
        }

 
        public async Task UpdateAsync(BookingVM bookingVM)
        {
            if (bookingVM == null) throw new ArgumentNullException(nameof(bookingVM));

            var booking = await _uow.Bookings.GetByIdWithDetailsAsync(bookingVM.Id);
            if (booking == null) return;

            _mapper.Map(bookingVM, booking); // Map changes onto entity
            await _uow.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var booking = await _uow.Bookings.GetByIdAsync(id);
            if (booking == null) return;
            await _uow.Bookings.DeleteAsync(booking);
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

        public async Task UpdateAsync(Booking booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking));

            // Get the existing booking from the database
            var existingBooking = await _uow.Bookings.GetByIdAsync(booking.Id);
            if (existingBooking == null)
                throw new InvalidOperationException($"Booking with Id {booking.Id} not found.");

            // Update the entity fields
            existingBooking.Status = booking.Status;
            existingBooking.PaymentStatus = booking.PaymentStatus;
            existingBooking.PaymentMethod = booking.PaymentMethod;
            existingBooking.TransactionId = booking.TransactionId;
            existingBooking.Notes = booking.Notes;
            existingBooking.CancellationReason = booking.CancellationReason;
            existingBooking.CancellationDate = booking.CancellationDate;
            existingBooking.UpdatedAt = DateTime.UtcNow;

            // Update numeric/financial fields if needed
            existingBooking.TotalPrice = booking.TotalPrice;
            existingBooking.DiscountAmount = booking.DiscountAmount;

            // Save changes
            _uow.Bookings.Update(existingBooking);
            await _uow.SaveAsync();
        }

    }
}
