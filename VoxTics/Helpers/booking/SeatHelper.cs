using System.Collections.Generic;
using System.Linq;

namespace VoxTics.Helpers.booking
{
    public static class SeatHelper
    {
        /// <summary>
        /// Returns a formatted string for selected seats (e.g., "A1, A2, B3").
        /// </summary>
        public static string FormatSeats(IEnumerable<string> seatNumbers)
        {
            return string.Join(", ", seatNumbers);
        }

        /// <summary>
        /// Checks if the requested seats are available.
        /// </summary>
        public static bool AreSeatsAvailable(IEnumerable<string> requestedSeats, IEnumerable<string> bookedSeats)
        {
            return !requestedSeats.Any(s => bookedSeats.Contains(s));
        }
    }
}
