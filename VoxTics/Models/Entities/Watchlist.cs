using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Models.Entities
{
    public class Watchlist : BaseEntity
    {
        // -------------------------
        // Foreign key
        // -------------------------
        [Required]
        public string UserId { get; set; } = default!;
        public string Name { get; set; } = "Default";

        // -------------------------
        // Navigation properties
        // -------------------------
        public virtual ApplicationUser User { get; set; } = default!;
        public virtual ICollection<WatchlistItem> WatchlistItems { get; set; } = new List<WatchlistItem>();
    }
}
