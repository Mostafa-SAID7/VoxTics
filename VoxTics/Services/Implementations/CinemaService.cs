using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Helpers.ImgsHelper;
using VoxTics.Models.ViewModels.Cinema;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemasRepository _cinemasRepository;
        private readonly IMapper _mapper;
        private readonly ImageManager _imageManager;

        public CinemaService(
            ICinemasRepository cinemasRepository,
            IMapper mapper,
            ImageManager imageManager)
        {
            _cinemasRepository = cinemasRepository ?? throw new ArgumentNullException(nameof(cinemasRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _imageManager = imageManager ?? throw new ArgumentNullException(nameof(imageManager));
        }

        // ---------------------------
        // PUBLIC METHODS
        // ---------------------------

        public async Task<IEnumerable<CinemaVM>> GetActiveCinemasAsync(CancellationToken cancellationToken = default)
        {
            var cinemas = await _cinemasRepository.GetActiveCinemasAsync(cancellationToken);
            var mapped = _mapper.Map<IEnumerable<CinemaVM>>(cinemas);

            // Attach display image paths
            foreach (var cinema in mapped)
            {
                cinema.DisplayImage = _imageManager.GetImageWebPath(
                    ImageType.Cinema,
                    cinema.Id.ToString(),
                    cinema.DisplayImage);
            }
            return mapped;
        }

        public async Task<(IEnumerable<CinemaVM> Items, int TotalCount)> GetPagedCinemasAsync(
            int page, int pageSize, string? search, string? sort, CancellationToken cancellationToken = default)
        {
            var (items, totalCount) = await _cinemasRepository.GetPagedCinemasAsync(page, pageSize, search, sort, cancellationToken);
            var mapped = _mapper.Map<IEnumerable<CinemaVM>>(items);

            foreach (var cinema in mapped)
            {
                cinema.DisplayImage = _imageManager.GetImageWebPath(
                    ImageType.Cinema,
                    cinema.Id.ToString(),
                    cinema.DisplayImage);
            }

            return (mapped, totalCount);
        }

        public async Task<CinemaDetailsVM?> GetCinemaDetailsAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            var cinema = await _cinemasRepository.GetCinemaDetailsAsync(id, cancellationToken);
            if (cinema == null) return null;

            var mapped = _mapper.Map<CinemaDetailsVM>(cinema);

            var files = _imageManager.GetImageFileNames(ImageType.Cinema, id.ToString());
            Console.WriteLine($"[DEBUG] Found files: {string.Join(", ", files)}");

            if (!string.IsNullOrWhiteSpace(cinema.DisplayImage) &&
                !cinema.DisplayImage.Contains("placeholder", StringComparison.OrdinalIgnoreCase))
            {
                mapped.DisplayImage = _imageManager.GetImageWebPath(
                    ImageType.Cinema,
                    id.ToString(),
                    cinema.DisplayImage);
            }
            else if (files.Length > 0)
            {
                mapped.DisplayImage = _imageManager.GetImageWebPath(
                    ImageType.Cinema,
                    id.ToString(),
                    files[0]);
            }
            else
            {
                mapped.DisplayImage = _imageManager.GetImageWebPath(
                    ImageType.Cinema,
                    id.ToString(),
                    null);
            }

            return mapped;
        }


        public async Task<string[]> GetCinemaImagesAsync(int cinemaId)
        {
            var cinema = await _cinemasRepository.GetByIdAsync(cinemaId);
            if (cinema == null) return Array.Empty<string>();

            return _imageManager.GetImageFileNames(ImageType.Cinema, cinema.Id.ToString());
        }

        public string GetCinemaImageWebPath(int cinemaId, string? imageName = null)
        {
            return _imageManager.GetImageWebPath(ImageType.Cinema, cinemaId.ToString(), imageName);
        }

        public string GetMainCinemaImagePath(int cinemaId, string? displayImage)
        {
            // Ensure non-empty image
            if (string.IsNullOrWhiteSpace(displayImage) || displayImage == "/images/defaults/placeholder.png")
            {
                // Try to find any gallery image first
                var images = _imageManager.GetImageFileNames(ImageType.Cinema, cinemaId.ToString());
                if (images.Length > 0)
                    return _imageManager.GetImageWebPath(ImageType.Cinema, cinemaId.ToString(), images[0]);
            }
            
            // Validate given display image path
            return _imageManager.GetImageWebPath(ImageType.Cinema, cinemaId.ToString(), displayImage);
        }
    }
}
