using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories;

namespace VoxTics.Repositories.IRepositories
{
    public interface ICinemasRepository : IBaseRepository<Cinema>
    {
        Task<IEnumerable<Cinema>> GetCinemasByCityAsync(string city);
    }

}
