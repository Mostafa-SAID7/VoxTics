namespace VoxTics.Areas.Admin.ViewModels
{
    public class ShowtimeViewModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CinemaId { get; set; }
        public DateTime StartTime { get; set; }
        public decimal Price { get; set; }
    }
}
