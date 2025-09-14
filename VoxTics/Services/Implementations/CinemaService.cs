using AutoMapper;
using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Data.UoW;
using VoxTics.Models.ViewModels.Cinema;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class CinemaService : ICinemaService
    {
        private readonly ICinemasRepository _cinemaRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CinemaService(ICinemasRepository cinemaRepo, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _cinemaRepo = cinemaRepo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Admin CRUD
        public async Task<List<CinemaViewModel>> GetAllAsync()
        {
            var cinemas = await _cinemaRepo.GetAllWithDetailsAsync();
            return _mapper.Map<List<CinemaViewModel>>(cinemas);
        }

        public async Task<CinemaViewModel?> GetByIdAsync(int id)
        {
            var cinema = await _cinemaRepo.GetCinemaWithDetailsAsync(id);
            return cinema == null ? null : _mapper.Map<CinemaViewModel>(cinema);
        }

        public async Task CreateAsync(CinemaViewModel vm)
        {
            var cinema = _mapper.Map<Cinema>(vm);

            // Handle Image Upload
            if (vm.ImageFile != null)
            {
                cinema.ImageUrl = await SaveImageAsync(vm.ImageFile);
            }

            

            await _cinemaRepo.AddAsync(cinema);
            await _cinemaRepo.SaveChangesAsync();
        }

        public async Task UpdateAsync(CinemaViewModel vm)
        {
            var cinema = await _cinemaRepo.GetByIdAsync(vm.Id);
            if (cinema == null) return;

            _mapper.Map(vm, cinema);
            cinema.UpdatedAt = DateTime.UtcNow;

            if (vm.ImageFile != null)
            {
                cinema.ImageUrl = await SaveImageAsync(vm.ImageFile);
            }

            _cinemaRepo.Update(cinema);
            await _cinemaRepo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cinema = await _cinemaRepo.GetByIdAsync(id);
            if (cinema == null) return;

            _cinemaRepo.DeleteAsync(cinema);
            await _cinemaRepo.SaveChangesAsync();
        }
        #endregion

        #region Public/Main
        public async Task<List<CinemaVM>> GetAllPublicAsync()
        {
            var cinemas = await _cinemaRepo.GetAllWithDetailsAsync();
            return _mapper.Map<List<CinemaVM>>(cinemas);
        }

        public async Task<CinemaVM?> GetByIdPublicAsync(int id)
        {
            var cinema = await _cinemaRepo.GetCinemaWithDetailsAsync(id);
            return cinema == null ? null : _mapper.Map<CinemaVM>(cinema);
        }
        #endregion

        #region Helpers
        private async Task<string> SaveImageAsync(IFormFile file)
        {
            // Example: save to wwwroot/images/cinemas and return relative path
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine("wwwroot/images/cinemas", fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return $"/images/cinemas/{fileName}";
        }
        #endregion
    }

}
