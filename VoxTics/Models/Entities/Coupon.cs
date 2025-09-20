using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.Entities
{
    public class Coupon : BaseEntity
    {
        [Required, MaxLength(50)]
        public string Code { get; set; } = string.Empty;

        [Required]
        [Range(0, 100, ErrorMessage = "Discount percentage must be between 0 and 100")]
        public decimal DiscountPercentage { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue)]
        public decimal? MaxDiscountAmount { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int? UsageLimit { get; set; }  // Optional: limit number of times it can be used
        public int UsedCount { get; set; } = 0;

        public bool IsActive { get; set; } = true;
        public bool IsApplied { get; set; } = false;
        // Navigation properties
        public int? BookingId { get; set; }
        [ForeignKey(nameof(BookingId))]
        public virtual Booking? Booking { get; set; }

        public int? CartId { get; set; }
        [ForeignKey(nameof(CartId))]
        public virtual Cart? Cart { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();

    }
}
