using System.ComponentModel.DataAnnotations.Schema;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Models.Entities
{
    public class Cart : BaseEntity
    {
        [Required]
        public string UserId { get; set; } = default!;

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = default!;

        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        [NotMapped]
        public decimal TotalAmount => CartItems?.Sum(ci => ci.Showtime.Price * ci.Quantity) ?? 0;

        [NotMapped]
        public int TotalTickets => CartItems?.Sum(ci => ci.Quantity) ?? 0;
        public int? CouponId { get; set; }
        [ForeignKey(nameof(CouponId))]
        public virtual Coupon? Coupon { get; set; }

        [NotMapped]
        public decimal TotalAmountAfterDiscount =>
            Coupon != null ? TotalAmount * (1 - Coupon.DiscountPercentage / 100) : TotalAmount;
    }

}
