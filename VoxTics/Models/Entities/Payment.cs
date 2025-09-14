using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.Entities
{
    public class Payment : BaseEntity
    {
        // -------------------------
        // Foreign key
        // -------------------------
        [Required]
        public int BookingId { get; set; }

        // -------------------------
        // Navigation property
        // -------------------------
        public virtual Booking Booking { get; set; } = null!;

        // -------------------------
        // Required fields
        // -------------------------
        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required, StringLength(100)]
        public string PaymentMethod { get; set; } = "Unknown";

        [Required]
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending;

        // -------------------------
        // Optional fields
        // -------------------------
        [StringLength(200)]
        public string? TransactionId { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [StringLength(1000)]
        public string? Notes { get; set; }
    }
}
