using System;
using System.Collections.Generic;

namespace VoxTics.Helpers.booking
{
    public static class BookingHelper
    {
        public static decimal CalculateBookingAmount(decimal seatPrice, IEnumerable<string> seats, decimal discountPercent = 0)
        {
            var total = PricingHelper.CalculateTotal(seatPrice, System.Linq.Enumerable.Count(seats));
            var discount = PricingHelper.ApplyDiscount(total, discountPercent);
            return PricingHelper.CalculateFinalAmount(total, total - discount);
        }

        public static string GetSeatSummary(IEnumerable<string> seats)
        {
            return SeatHelper.FormatSeats(seats);
        }
    }
}
