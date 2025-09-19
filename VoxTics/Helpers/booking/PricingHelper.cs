using System;

namespace VoxTics.Helpers.booking
{
    public static class PricingHelper
    {
        /// <summary>
        /// Calculate total price for seats.
        /// </summary>
        public static decimal CalculateTotal(decimal seatPrice, int seatCount)
        {
            return seatPrice * seatCount;
        }

        /// <summary>
        /// Apply a discount percentage to a total amount.
        /// </summary>
        public static decimal ApplyDiscount(decimal totalAmount, decimal discountPercent)
        {
            if (discountPercent <= 0) return totalAmount;
            return totalAmount - (totalAmount * discountPercent / 100m);
        }

        /// <summary>
        /// Calculate final amount after discount and any fees.
        /// </summary>
        public static decimal CalculateFinalAmount(decimal totalAmount, decimal discountAmount, decimal fees = 0)
        {
            return totalAmount - discountAmount + fees;
        }
    }
}
