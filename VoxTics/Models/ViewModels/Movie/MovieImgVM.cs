namespace VoxTics.Models.ViewModels.Movie
{
    public class MovieImgVM
    {
        public int Id { get; set; }               // MovieImg.Id (BaseEntity)
        public string FileName { get; set; } = string.Empty; // stored file name (or path)
        public string? AltText { get; set; }
        public bool IsMain { get; set; }
        public string Url { get; set; } = string.Empty; // full URL (filled by service)
    }
}
