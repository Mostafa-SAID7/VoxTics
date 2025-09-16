using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels.Actor;

namespace VoxTics.Repositories.IRepositories
{
    public interface IActorsRepository : IBaseRepository<Actor>
    {
        Task<PaginatedList<ActorVM>> GetPagedActorsAsync(
            int pageIndex,
            int pageSize,
            string? search = null,
            string? sortColumn = null,
            bool sortDesc = false,
            CancellationToken cancellationToken = default);

        Task<ActorDetailsVM?> GetActorDetailsAsync(
            int id,
            CancellationToken cancellationToken = default);
    }
}
