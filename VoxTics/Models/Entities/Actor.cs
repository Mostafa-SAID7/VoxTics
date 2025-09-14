using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.Entities
{
    public class Actor : BaseEntity
    {
        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [NotMapped]
        public string FullName
        {
            get => $"{FirstName} {LastName}".Trim();
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value), "FullName cannot be null.");

                var parts = value.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
                FirstName = parts.Length > 0 ? parts[0] : string.Empty;
                LastName = parts.Length > 1 ? parts[1] : string.Empty;
            }
        }

        [MaxLength(500)]
        public string? Bio { get; set; }

        [MaxLength(250)]
        public string? ImageUrl { get; set; } // Changed Uri? to string? for EF Core compatibility

        [MaxLength(100)]
        public string? Nationality { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? DateOfBirth { get; set; }

        [NotMapped]
        public int? Age
        {
            get
            {
                if (!DateOfBirth.HasValue) return null;
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Value.Year;
                if (DateOfBirth.Value.Date > today.AddYears(-age)) age--;
                return age;
            }
        }

        // Navigation properties
        public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
        public virtual ICollection<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();
    }
}
