using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VoxTics.Areas.Identity.Models.Entities;

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
        public string UserId { get; set; } = default!;
        public ApplicationUser User { get; set; } = null!;
        [Required, StringLength(100)]
        public PaymentMethod Method { get; set; } 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PaidAt { get; set; }

    }
}
