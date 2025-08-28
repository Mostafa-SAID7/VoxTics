namespace VoxTics.Areas.Admin.ViewModels.MovieVMs
{
    public class MovieDeleteVm
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string? CinemaName { get; set; }
        public string? CategoryName { get; set; }
        public string? ImgUrl { get; set; }
        public List<MovieImgVm> Images { get; set; } = new List<MovieImgVm>();

    }
}
