using VoxTics.Data;
using VoxTics.Models.Entities;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Repositories.Implementations
{
    public class ShowtimeRepository : BaseRepository<Showtime>, IShowtimeRepository
    {
        public ShowtimeRepository(MovieDbContext context) : base(context)
        {
        }
    }
}
