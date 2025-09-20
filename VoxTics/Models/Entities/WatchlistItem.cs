using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class WatchlistItem : BaseEntity
    {
        [Required]
        public int WatchlistId { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        public virtual Watchlist Watchlist { get; set; } = null!;

        [Required]
        public virtual Movie Movie { get; set; } = null!;

        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    }
}
