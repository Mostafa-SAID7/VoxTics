using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Helpers;
using VoxTics.Models.Entities;
using VoxTics.Repositories.IRepositories;

namespace VoxTics.Areas.Admin.Repositories
{
    public class AdminCinemasRepository : IAdminCinemasRepository
    {
        private readonly IBaseRepository<Cinema> _repository;
        private readonly IMapper _mapper;

        public AdminCinemasRepository(IBaseRepository<Cinema> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // ----------------- Helpers -----------------
        private static IQueryable<Cinema> ApplySorting(
            IQueryable<Cinema> query,
            string? sortColumn,
            bool sortDescending)
        {
            return sortColumn?.ToLower() switch
            {
                "name" => sortDescending ? query.OrderByDescending(c => c.Name) : query.OrderBy(c => c.Name),
                "city" => sortDescending ? query.OrderByDescending(c => c.City) : query.OrderBy(c => c.City),
                _ => query.OrderBy(c => c.Id)
            };
        }

        private static string NormalizeSlug(string name) =>
            name.ToLower().Replace(" ", "-");

        private async Task<Cinema> GetCinemaOrThrowAsync(int id, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(id, cancellationToken);
            return entity ?? throw new InvalidOperationException("Cinema not found");
        }

        // ----------------- Paging -----------------
        public async Task<PaginatedList<Cinema>> GetPagedAsync(
            int pageIndex,
            int pageSize,
            string? search,
            string? sortColumn,
            bool sortDescending,
            CancellationToken cancellationToken = default)
        {
            var query = _repository.Query();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(c => c.Name.Contains(search));

            query = ApplySorting(query, sortColumn, sortDescending);

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new PaginatedList<Cinema>(items, totalCount, pageIndex, pageSize);
        }

        // ----------------- CRUD -----------------
        public async Task<Cinema?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            return await _repository.GetByIdAsync(id, cancellationToken);
        }

        public async Task AddAsync(Cinema entity, CancellationToken cancellationToken = default)
        {
            await _repository.AddAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(Cinema entity, CancellationToken cancellationToken = default)
        {
            await _repository.UpdateAsync(entity, cancellationToken);
        }

        public async Task RemoveAsync(Cinema entity, CancellationToken cancellationToken = default)
        {
            await _repository.RemoveAsync(entity, cancellationToken);
        }

        public async Task CommitAsync()
        {
            await _repository.CommitAsync();
        }

        // ----------------- Validation -----------------
        public async Task<bool> SlugExistsAsync(
            string slug,
            int? excludeId = null,
            CancellationToken cancellationToken = default)
        {
            // Normalize slug for comparison using EF Core supported methods
            slug = slug.ToLower();

            var query = _repository.Query()
                .Where(c => c.Name.ToLower().Replace(" ", "-") == slug);

            if (excludeId.HasValue)
                query = query.Where(c => c.Id != excludeId.Value);

            return await query.AnyAsync(cancellationToken);
        }


        // ----------------- Convenience Methods -----------------
        public async Task CreateAsync(
            CinemaCreateEditViewModel model,
            CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<Cinema>(model);
            await AddAsync(entity, cancellationToken);
            await CommitAsync();
        }

        public async Task UpdateFromViewModelAsync(
            CinemaCreateEditViewModel model,
            CancellationToken cancellationToken = default)
        {
            var entity = await GetCinemaOrThrowAsync(model.Id, cancellationToken);
            _mapper.Map(model, entity);
            await UpdateAsync(entity, cancellationToken);
            await CommitAsync();
        }

        public async Task DeleteAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            var entity = await GetCinemaOrThrowAsync(id, cancellationToken);
            await RemoveAsync(entity, cancellationToken);
            await CommitAsync();
        }

        public async Task<CinemaDetailsViewModel?> GetDetailsByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            return entity == null ? null : _mapper.Map<CinemaDetailsViewModel>(entity);
        }
    }
}
