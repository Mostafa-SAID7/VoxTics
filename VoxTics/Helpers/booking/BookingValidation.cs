using System;
using System.Collections.Generic;

namespace VoxTics.Helpers.booking
{
    public static class BookingValidation
    {
        /// <summary>
        /// Checks if booking time is valid (not in the past).
        /// </summary>
        public static bool IsShowtimeValid(DateTime showtime)
        {
            return showtime > DateTime.UtcNow;
        }

        /// <summary>
        /// Validates seat selection.
        /// </summary>
        public static bool AreSeatsSelected(IEnumerable<string> seats)
        {
            return seats != null && System.Linq.Enumerable.Any(seats);
        }
    }
}
