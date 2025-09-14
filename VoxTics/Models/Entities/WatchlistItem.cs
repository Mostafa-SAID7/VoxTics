using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class WatchlistItem : BaseEntity
    {
        // -------------------------
        // Foreign keys
        // -------------------------
        [Required]
        public int WatchlistId { get; set; }

        [Required]
        public int MovieId { get; set; }

        // -------------------------
        // Navigation properties
        // -------------------------
        public virtual Watchlist Watchlist { get; set; } = null!;
        public virtual Movie Movie { get; set; } = null!;
    }
}
