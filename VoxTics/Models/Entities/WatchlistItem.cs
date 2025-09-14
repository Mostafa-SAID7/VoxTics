using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.Entities
{
    public class WatchlistItem : BaseEntity
    {
        [Required]
        public int WatchlistId { get; set; }

        [ForeignKey(nameof(WatchlistId))]
        public virtual Watchlist Watchlist { get; set; } = null!;

        [Required]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; } = null!;
    }
}
