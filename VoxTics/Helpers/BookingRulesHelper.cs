namespace VoxTics.Helpers
{
    /// <summary>
    /// Provides centralized domain rules and validation logic for booking operations.
    /// Keeps services clean and rules consistent across the app.
    /// </summary>
    public static class BookingRulesHelper
    {
        /// <summary>
        /// Maximum number of seats a user can book in one transaction.
        /// </summary>
        public const int MaxSeatsPerBooking = 6;

        /// <summary>
        /// Minimum number of minutes before showtime after which cancellations are not allowed.
        /// </summary>
        public const int CancellationCutoffMinutes = 30;

        /// <summary>
        /// Validates the number of seats and throws an exception if it exceeds the maximum allowed.
        /// </summary>
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

        /// <summary>
        /// Determines if a booking can still be cancelled based on its showtime.
        /// </summary>
        /// <param name="booking">The booking to check.</param>
        /// <returns>True if cancellation is allowed; otherwise false.</returns>
        public static bool CanCancel(Booking booking)
        {
            if (booking == null)
                throw new ArgumentNullException(nameof(booking));

            if (booking.Showtime == null)
                throw new InvalidOperationException("Booking must include a Showtime reference.");

            var cutoffTime = booking.Showtime.StartTime.AddMinutes(-CancellationCutoffMinutes);
            return DateTime.UtcNow <= cutoffTime;
        }

        /// <summary>
        /// Determines if a showtime is in the future.
        /// </summary>
        /// <param name="showtimeStart">The start time of the showtime.</param>
        /// <returns>True if the showtime is upcoming; otherwise false.</returns>
        public static bool IsUpcoming(DateTime showtimeStart)
        {
            return showtimeStart > DateTime.UtcNow;
        }

        /// <summary>
        /// Returns a human-readable string for the cancellation cutoff policy.
        /// Useful for displaying to users in UI or email templates.
        /// </summary>
        public static string GetCancellationPolicyDescription()
        {
            return $"Cancellations are allowed up to {CancellationCutoffMinutes} minutes before showtime.";
        }
    }
}
