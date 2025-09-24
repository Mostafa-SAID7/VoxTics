using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VoxTics.Areas.Admin.Repositories.IRepositories;
using VoxTics.Areas.Admin.Services.Interfaces;
using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Helpers.ImgsHelper;
using VoxTics.Models.Entities;

namespace VoxTics.Areas.Admin.Services.Implementations
{
    public class AdminCinemasService : IAdminCinemasService
    {
        private readonly IAdminCinemasRepository _cinemaRepo;
        private readonly IMapper _mapper;
        private readonly ImageManager _imageManager;

        public AdminCinemasService(
            IAdminCinemasRepository cinemaRepo,
            IMapper mapper,
            ImageManager imageManager)
        {
            _cinemaRepo = cinemaRepo ?? throw new ArgumentNullException(nameof(cinemaRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _imageManager = imageManager ?? throw new ArgumentNullException(nameof(imageManager));
        }

        // ---------- Paging ----------
        public async Task<PaginatedList<CinemaViewModel>> GetPagedAsync(
            int pageIndex,
            int pageSize,
            string? search = null,
            string? sortColumn = null,
            bool sortDescending = false,
            CancellationToken cancellationToken = default)
        {
            var pagedEntities = await _cinemaRepo.GetPagedAsync(pageIndex, pageSize, search, sortColumn, sortDescending, cancellationToken);
            var vms = pagedEntities.Items.Select(c => _mapper.Map<CinemaViewModel>(c)).ToList();
            return new PaginatedList<CinemaViewModel>(vms, pagedEntities.TotalCount, pageIndex, pageSize);
        }

        // ---------- Details ----------
        public async Task<CinemaDetailsViewModel?> GetDetailsByIdAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            var entity = await _cinemaRepo.GetByIdAsync(id, cancellationToken);
            return entity == null ? null : _mapper.Map<CinemaDetailsViewModel>(entity);
        }

        // ---------- Create ----------
        public async Task CreateAsync(
            CinemaCreateEditViewModel model,
            CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<Cinema>(model);

            // Handle optional image upload
            if (model.ImageFile != null && _imageManager.IsValidImageFile(model.ImageFile))
            {
                var fileName = await _imageManager.SaveImageAsync(model.ImageFile, ImageType.Cinema, entity.Name);
                entity.ImageUrl = fileName;
            }

            await _cinemaRepo.AddAsync(entity, cancellationToken);
            await _cinemaRepo.CommitAsync();
        }

        // ---------- Update ----------
        public async Task UpdateAsync(
            CinemaCreateEditViewModel model,
            CancellationToken cancellationToken = default)
        {
            var entity = await _cinemaRepo.GetByIdAsync(model.Id, cancellationToken)
                         ?? throw new InvalidOperationException("Cinema not found");

            // Map updated fields
            _mapper.Map(model, entity);

            // Handle image update
            if (model.ImageFile != null && _imageManager.IsValidImageFile(model.ImageFile))
            {
                if (!string.IsNullOrEmpty(entity.ImageUrl))
                    _imageManager.DeleteFile(ImageType.Cinema, entity.Name, entity.ImageUrl);

                var fileName = await _imageManager.SaveImageAsync(model.ImageFile, ImageType.Cinema, entity.Name);
                entity.ImageUrl = fileName;
            }

            await _cinemaRepo.UpdateAsync(entity, cancellationToken);
            await _cinemaRepo.CommitAsync();
        }

        // ---------- Delete ----------
        public async Task DeleteAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            var entity = await _cinemaRepo.GetByIdAsync(id, cancellationToken)
                         ?? throw new InvalidOperationException("Cinema not found");

            _imageManager.DeleteFolder(ImageType.Cinema, entity.Name);

            await _cinemaRepo.RemoveAsync(entity, cancellationToken);
            await _cinemaRepo.CommitAsync();
        }

        // ---------- Slug Check ----------
        public async Task<bool> SlugExistsAsync(
            string slug,
            int? excludeId = null,
            CancellationToken cancellationToken = default)
        {
            return await _cinemaRepo.SlugExistsAsync(slug, excludeId, cancellationToken);
        }
    }
}
