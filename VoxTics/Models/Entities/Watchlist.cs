using System.ComponentModel.DataAnnotations.Schema;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Models.Entities
{
    public class Watchlist : BaseEntity
    {
        [Required]
        public string UserId { get; set; } = default!;

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } = default!;

        public virtual ICollection<WatchlistItem> WatchlistItems { get; set; } = new List<WatchlistItem>();
    }
}
