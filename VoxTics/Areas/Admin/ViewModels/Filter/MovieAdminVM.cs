namespace VoxTics.Areas.Admin.ViewModels.Filter
{
    public class MovieAdminVM
    {
        public MovieFilterVM Filter { get; set; } = new MovieFilterVM();
        public PagedResultVM<MovieVM> Movies { get; set; } = new PagedResultVM<MovieVM>();
    }
}
