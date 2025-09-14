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
        public decimal TotalAmount => CartItems?.Sum(ci => ci.Price * ci.Quantity) ?? 0;

        [NotMapped]
        public int TotalTickets => CartItems?.Sum(ci => ci.Quantity) ?? 0;
        public ICollection<BookingSeat> BookingSeats { get; set; } = new List<BookingSeat>();

    }
}
