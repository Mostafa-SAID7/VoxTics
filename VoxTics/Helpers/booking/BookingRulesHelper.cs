namespace VoxTics.Helpers.booking
{

    public static class BookingRulesHelper
    {
   
        public const int MaxSeatsPerBooking = 6;

        public static bool IsSeatCountValid(IEnumerable<string> seats)
        {
            return seats != null && System.Linq.Enumerable.Count(seats) <= MaxSeatsPerBooking;
        }

        public static bool IsEligibleForDiscount(decimal totalAmount, decimal minAmountForDiscount)
        {
            return totalAmount >= minAmountForDiscount;
        }
        public const int CancellationCutoffMinutes = 30;

        
        /// <param name="seatNumbers">The selected seat numbers.</param>
        /// <exception cref="InvalidOperationException">Thrown if booking exceeds the limit.</exception>
        public static void EnsureBookingLimit(IEnumerable<string> seatNumbers)
        {
            if (seatNumbers == null)
                throw new ArgumentNullException(nameof(seatNumbers));

            var count = seatNumbers.Count();
            if (count > MaxSeatsPerBooking)
            {
                throw new InvalidOperationException(
                    $"Cannot book more than {MaxSeatsPerBooking} seats per booking. Requested: {count}");
            }
        }

 
        public static bool CanCancel(Booking booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking));

            if (booking.Showtime == null)
                throw new InvalidOperationException("Booking must include a Showtime reference.");

            var cutoffTime = booking.Showtime.StartTime.AddMinutes(-CancellationCutoffMinutes);
            return DateTime.UtcNow <= cutoffTime;
        }

        public static bool IsUpcoming(DateTime showtimeStart)
        {
            return showtimeStart > DateTime.UtcNow;
        }
        public static string GetCancellationPolicyDescription()
        {
            return $"Cancellations are allowed up to {CancellationCutoffMinutes} minutes before showtime.";
        }
    }
}
