using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Entities
{
    public class MovieActor : BaseEntity
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        public int ActorId { get; set; }

        public string? CharacterName { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public virtual Actor Actor { get; set; } = null!;
    }
}
