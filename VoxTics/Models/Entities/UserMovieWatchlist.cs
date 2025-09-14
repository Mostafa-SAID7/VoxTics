using VoxTics.Areas.Identity.Models.Entities;

namespace VoxTics.Models.Entities
{
    public class UserMovieWatchlist
    {
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; } = null!;
    }
}
