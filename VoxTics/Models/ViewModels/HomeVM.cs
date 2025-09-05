namespace VoxTics.Models.ViewModels
{
    public class HomeVM
    {
        public List<MovieVM> Movies { get; set; } = new();
        public List<CinemaVM> Cinemas { get; set; } = new();
        public List<ShowtimeVM> Showtimes { get; set; } = new();
    }
}
