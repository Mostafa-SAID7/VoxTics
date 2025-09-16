using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    /// <summary>
    /// Represents a discount or promotional coupon for bookings.
    /// </summary>
    public class Coupon
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Code { get; set; } = string.Empty;

        [Required, Range(0, 100, ErrorMessage = "Discount percentage must be between 0 and 100.")]
        public decimal DiscountPercentage { get; set; }

        /// <summary>
        /// Optional fixed amount discount (can be combined with percentage if needed).
        /// </summary>
        [Range(0, double.MaxValue)]
        public decimal? FixedAmount { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        /// <summary>
        /// Maximum number of times this coupon can be used across all users.
        /// </summary>
        public int? UsageLimit { get; set; }

        /// <summary>
        /// Number of times the coupon has been redeemed.
        /// </summary>
        public int TimesUsed { get; set; } = 0;

        /// <summary>
        /// Minimum booking amount to apply this coupon.
        /// </summary>
        [Range(0, double.MaxValue)]
        public decimal MinimumSpend { get; set; } = 0;

        /// <summary>
        /// Indicates whether this coupon is active.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Navigation property for bookings that used this coupon.
        /// </summary>
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
