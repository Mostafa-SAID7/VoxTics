namespace VoxTics.Helpers.booking
{
    public static class CartExtensions
    {
        public static List<Booking> ConvertCartToBookings(this Cart cart, PaymentMethod paymentMethod, decimal discount = 0)
        {
            if (cart == null) throw new ArgumentNullException(nameof(cart));
            if (!cart.CartItems.Any()) throw new InvalidOperationException("Cart is empty.");

            var bookings = new List<Booking>();

            foreach (var item in cart.CartItems)
            {
                var booking = new Booking
                {
                    UserId = cart.UserId,
                    ShowtimeId = item.ShowtimeId,
                    NumberOfTickets = item.Quantity,
                    TotalAmount = item.Showtime.Price * item.Quantity,
                    DiscountAmount = discount,
                    FinalAmount = (item.Showtime.Price * item.Quantity) - discount,
                    Status = BookingStatus.Pending,
                   
                    BookingDate = DateTime.UtcNow
                };

                foreach (var seat in item.Seats)
                {
                    booking.BookingSeats.Add(new BookingSeat
                    {
                        SeatId = seat.Id,
                        SeatPrice = item.Showtime.Price
                    });
                }

                bookings.Add(booking);
            }

            return bookings;
        }
    }


}
