using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class Actor
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public string FullName { get; set; } = string.Empty;

        public string? Bio { get; set; }

        public string? PhotoUrl { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
    }
}
