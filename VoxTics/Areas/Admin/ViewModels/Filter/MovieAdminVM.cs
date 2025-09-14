using VoxTics.Models.ViewModels.Movie;

namespace VoxTics.Areas.Admin.ViewModels.Filter
{
    public class MovieHomeVM
    {
        public MoviesFilterVM Filter { get; set; } = new MoviesFilterVM();
        public PagedResultVM<MovieVM> Movies { get; set; } = new PagedResultVM<MovieVM>();
    }
}
