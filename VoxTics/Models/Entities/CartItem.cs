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
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; } = null!;

        [Required]
        public int ShowtimeId { get; set; }
        [ForeignKey(nameof(ShowtimeId))]
        public virtual Showtime Showtime { get; set; } = null!;

        [Required, Range(1, 20)]
        public int Quantity { get; set; } = 1;

        public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

        [NotMapped]
        public decimal TotalPrice => (Showtime?.Price ?? 0) * Quantity;

        [NotMapped]
        public string SeatLabels => Seats is null || !Seats.Any()
            ? string.Empty
            : string.Join(", ", Seats.Select(s => s.SeatNumber));
    }

}
