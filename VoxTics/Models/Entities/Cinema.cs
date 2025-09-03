using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class Cinema
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public string Name { get; set; } = string.Empty;

        public string? Address { get; set; }

        public ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}
