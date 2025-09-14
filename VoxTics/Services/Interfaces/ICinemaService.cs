using VoxTics.Areas.Admin.ViewModels.Cinema;
using VoxTics.Models.ViewModels.Cinema;

namespace VoxTics.Services.Interfaces
{
    public interface ICinemaService
    {
        // Admin CRUD
        Task<List<CinemaViewModel>> GetAllAsync();
        Task<CinemaViewModel?> GetByIdAsync(int id);
        Task CreateAsync(CinemaViewModel vm);
        Task UpdateAsync(CinemaViewModel vm);
        Task DeleteAsync(int id);
        // Main/Public
        Task<List<CinemaVM>> GetAllPublicAsync();
        Task<CinemaVM?> GetByIdPublicAsync(int id);
    }

}
