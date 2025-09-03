namespace VoxTics.Models.Entities
{
    public class MovieImg
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; } = string.Empty; // relative URL, e.g. /uploads/movies/xxx.jpg

        public string? AltText { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
    }
}
