using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels.Showtime;
using VoxTics.Data.UoW;
using VoxTics.Models.Entities;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces;

namespace VoxTics.Services.Implementations
{
    public class AdminShowtimeService : IAdminShowtimeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminShowtimeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<ShowtimeViewModel>> GetPagedShowtimesAsync(string? searchTerm = null, int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.AdminShowtimes.GetPagedShowtimesAsync(searchTerm, pageNumber, pageSize, cancellationToken);
        }

        public Task<int> CountShowtimesAsync(string? searchTerm = null, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.AdminShowtimes.CountShowtimesAsync(searchTerm, cancellationToken);
        }

        public Task<ShowtimeDetailsViewModel?> GetShowtimeDetailsAsync(int id, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.AdminShowtimes.GetShowtimeDetailsAsync(id, cancellationToken);
        }

        public Task<bool> ShowtimeExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.AdminShowtimes.ShowtimeExistsAsync(id, cancellationToken);
        }

        public async Task AddShowtimeAsync(Showtime showtime, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.AdminShowtimes.AddShowtimeAsync(showtime, cancellationToken);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateShowtimeAsync(Showtime showtime, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.AdminShowtimes.UpdateShowtimeAsync(showtime, cancellationToken);
            await _unitOfWork.CommitAsync();
        }

        public async Task RemoveShowtimeAsync(int id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.AdminShowtimes.RemoveShowtimeAsync(id, cancellationToken);
            await _unitOfWork.CommitAsync();
        }

        public Task<Showtime?> GetShowtimeByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _unitOfWork.AdminShowtimes.GetByIdAsync(id, cancellationToken);
        }
    }
}
