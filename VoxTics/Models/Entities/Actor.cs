using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.Entities
{
    public class Actor : BaseEntity
    {
      
      
        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;
     

        [MaxLength(500)]
        public string? Bio { get; set; }

        [MaxLength(250)]
        public string? ImageUrl { get; set; } // Changed Uri? to string? for EF Core compatibility

        [MaxLength(100)]
        public string? Nationality { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? DateOfBirth { get; set; }

        // Navigation properties
        public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
        public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();
    }
}
