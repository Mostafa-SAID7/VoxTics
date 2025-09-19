using Microsoft.EntityFrameworkCore;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Actor;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Repositories
{
    public class ActorsRepository : BaseRepository<Actor>, IActorsRepository
    {
        private readonly MovieDbContext _context;

        public ActorsRepository(MovieDbContext context) : base(context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a paginated list of actors for the Index page.
        /// </summary>
        public async Task<PaginatedList<ActorVM>> GetPagedActorsAsync(
            int pageIndex,
            int pageSize,
            string? search = null,
            string? sortColumn = null,
            bool sortDesc = false,
            CancellationToken cancellationToken = default)
        {
            var query = _context.Actors.AsNoTracking()
                .Select(a => new ActorVM
                {
                    Id = a.Id,
                    ImageUrl = a.ImageUrl
                });

            // Optional search
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(a => a.FullName.Contains(search));
            }

            // Use QueryableExtensions.GetPaged for sorting and pagination
            var paged = query.GetPaged(
                pageIndex: pageIndex,
                pageSize: pageSize,
                searchString: search,
                searchFunc: q => q.Where(a => a.FullName.Contains(search!)),
                sortColumn: sortColumn ?? nameof(ActorVM.FullName),
                sortDescending: sortDesc
            );

            return await Task.FromResult(paged).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets detailed information for a single actor.
        /// </summary>
        public async Task<ActorDetailsVM?> GetActorDetailsAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            return await _context.Actors
                .Where(a => a.Id == id)
                .Select(a => new ActorDetailsVM
                {
                    Id = a.Id,

                    Bio = a.Bio,
                    ImageUrl = a.ImageUrl,
                    DateOfBirth = a.DateOfBirth
                })
                .AsNoTracking()
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);
        }
    }
}
