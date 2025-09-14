using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.Entities
{
    public class CartItem : BaseEntity
    {
        [Required]
        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public virtual Cart Cart { get; set; } = null!;

        [Required]
        public int ShowtimeId { get; set; }

        [ForeignKey(nameof(ShowtimeId))]
        public virtual Showtime Showtime { get; set; } = null!;

        [Required]
        [Range(1, 20)]
        public int Quantity { get; set; } = 1;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [NotMapped]
        public decimal Total => Quantity * Price;
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    }
}
