using AutoMapper;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Admin.Services.Interfaces;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Areas.Admin.ViewModels.Filter;
using VoxTics.Areas.Admin.ViewModels.Movie;
using MovieFilterVM = VoxTics.Areas.Admin.ViewModels.Filter.MovieFilterVM;

namespace VoxTics.Areas.Admin.Service.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public MovieService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PagedResultVM<MovieListItemViewModel>> GetPagedAsync(MovieFilterVM filter)
        {
            var paginated = await _uow.Movies.GetPagedAsync(filter);

            var items = _mapper.Map<List<MovieListItemViewModel>>(paginated.Items);

            var result = new PagedResultVM<MovieListItemViewModel>
            {
                Items = items,
                PageIndex = paginated.PageIndex,
                PageSize = paginated.PageSize,
                TotalCount = paginated.TotalCount,
                TotalPages = paginated.TotalPages,
                PageNumbers = paginated.GetPageNumbers()
            };

            return result;
        }

        public async Task<MovieDetailViewModel?> GetDetailsAsync(int id)
        {
            var movie = await _uow.Movies.GetByIdWithDetailsAsync(id);
            if (movie == null) return null;
            return _mapper.Map<MovieDetailViewModel>(movie);
        }

        public async Task<int> CreateAsync(MovieCreateEditViewModel vm)
        {
            // Start transaction
            await using var tx = await _uow.BeginTransactionAsync();
            try
            {
                // Map scalars
                var movie = _mapper.Map<Movie>(vm);

                // relations
                movie.MovieActors = (vm.SelectedActorIds ?? new List<int>()).Select(aid => new MovieActor { ActorId = aid }).ToList();
                movie.MovieCategories = (vm.SelectedCategoryIds ?? new List<int>()).Select(cid => new MovieCategory { CategoryId = cid }).ToList();
                movie.MovieImages = (vm.ImageUrls ?? new List<string>()).Select(url => new MovieImg { ImageUrl = url }).ToList();

                _uow.Movies.Add(movie);
                await _uow.SaveAsync();

                await tx.CommitAsync();
                return movie.Id;
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }

        public async Task UpdateAsync(MovieCreateEditViewModel vm)
        {
            if (!vm.Id.HasValue) throw new ArgumentException("Id is required for update");

            await using var tx = await _uow.BeginTransactionAsync();
            try
            {
                // get tracked entity with includes
                var movie = await _uow.Movies.QueryWithIncludes(false).FirstOrDefaultAsync(m => m.Id == vm.Id.Value);
                if (movie == null) throw new KeyNotFoundException("Movie not found");

                // map scalar fields
                _mapper.Map(vm, movie); // our mapping ignores relations so safe to use

                // --- Sync Actors ---
                var incomingActorIds = new HashSet<int>(vm.SelectedActorIds ?? new List<int>());
                movie.MovieActors ??= new List<MovieActor>();

                // remove unselected
                var toRemoveActors = movie.MovieActors.Where(ma => !incomingActorIds.Contains(ma.ActorId)).ToList();
                foreach (var r in toRemoveActors)
                    movie.MovieActors.Remove(r);

                // add new ones
                var existingActorIds = movie.MovieActors.Select(ma => ma.ActorId).ToHashSet();
                var toAddActorIds = incomingActorIds.Where(id => !existingActorIds.Contains(id));
                foreach (var id in toAddActorIds)
                    movie.MovieActors.Add(new MovieActor { ActorId = id });

                // --- Sync Categories ---
                var incomingCatIds = new HashSet<int>(vm.SelectedCategoryIds ?? new List<int>());
                movie.MovieCategories ??= new List<MovieCategory>();

                var toRemoveCats = movie.MovieCategories.Where(mc => !incomingCatIds.Contains(mc.CategoryId)).ToList();
                foreach (var r in toRemoveCats)
                    movie.MovieCategories.Remove(r);

                var existingCatIds = movie.MovieCategories.Select(mc => mc.CategoryId).ToHashSet();
                var toAddCatIds = incomingCatIds.Where(id => !existingCatIds.Contains(id));
                foreach (var id in toAddCatIds)
                    movie.MovieCategories.Add(new MovieCategory { CategoryId = id });

                // --- Sync Images (by URL) ---
                var incomingUrls = vm.ImageUrls ?? new List<string>();
                movie.MovieImages ??= new List<MovieImg>();

                var toRemoveImgs = movie.MovieImages.Where(mi => !incomingUrls.Contains(mi.ImageUrl)).ToList();
                foreach (var r in toRemoveImgs)
                    movie.MovieImages.Remove(r);

                var existingUrls = movie.MovieImages.Select(mi => mi.ImageUrl).ToHashSet();
                var toAddUrls = incomingUrls.Where(u => !existingUrls.Contains(u));
                foreach (var url in toAddUrls)
                    movie.MovieImages.Add(new MovieImg { ImageUrl = url });

                // update tracked entity
                _uow.Movies.Update(movie);
                await _uow.SaveAsync();

                await tx.CommitAsync();
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            await using var tx = await _uow.BeginTransactionAsync();
            try
            {
                // load tracked entity with includes
                var movie = await _uow.Movies.QueryWithIncludes(false).FirstOrDefaultAsync(m => m.Id == id);
                if (movie == null) throw new KeyNotFoundException("Movie not found");

                // If cascade deletes are configured in EF, removing the movie is enough.
                // Otherwise, explicitly remove related collections first.
                // Remove MovieImgs
                if (movie.MovieImages != null && movie.MovieImages.Any())
                    _uow.MovieImgs.RemoveRange(movie.MovieImages);

                // Remove MovieActors
                if (movie.MovieActors != null && movie.MovieActors.Any())
                {
                    // If you have a repository for MovieActor, call it; else remove through the context tracking:
                    foreach (var ma in movie.MovieActors.ToList())
                        movie.MovieActors.Remove(ma);
                }

                // Remove MovieCategories
                if (movie.MovieCategories != null && movie.MovieCategories.Any())
                {
                    foreach (var mc in movie.MovieCategories.ToList())
                        movie.MovieCategories.Remove(mc);
                }

                _uow.Movies.Remove(movie);
                await _uow.SaveAsync();

                await tx.CommitAsync();
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }
    }
    }
