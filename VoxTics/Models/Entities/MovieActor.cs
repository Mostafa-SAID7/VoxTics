using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.Entities
{
    public class MovieActor : BaseEntity
    {
        // Foreign Keys
        [Required]
        public int MovieId { get; set; }

        [Required]
        public int ActorId { get; set; }

        // Navigation properties
        public virtual Movie Movie { get; set; } = null!;
        public virtual Actor Actor { get; set; } = null!;
    }
}
