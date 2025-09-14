using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Models.Entities
{
    public class UserMovieWatchlist
    {
        // -------------------------
        // Foreign keys
        // -------------------------
        public string UserId { get; set; } = default!;
        public int MovieId { get; set; }

        // -------------------------
        // Navigation properties
        // -------------------------
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual Movie Movie { get; set; } = null!;
    }
}
