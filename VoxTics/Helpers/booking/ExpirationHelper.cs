using System;

namespace VoxTics.Helpers.booking
{
    public static class ExpirationHelper
    {
        /// <summary>
        /// Checks if a booking has expired.
        /// </summary>
        public static bool HasBookingExpired(DateTime bookingTime, int minutesToExpire = 15)
        {
            return DateTime.UtcNow > bookingTime.AddMinutes(minutesToExpire);
        }
    }
}
