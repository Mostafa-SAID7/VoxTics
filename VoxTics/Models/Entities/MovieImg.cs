using System.ComponentModel.DataAnnotations;
namespace VoxTics.Models.Entities
{
    public class MovieImg
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsPrimary { get; set; } = false;

        public string? AltText { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
    }
}
