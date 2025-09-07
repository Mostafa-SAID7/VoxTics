using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VoxTics.Models.Entities
{
    public class Actor : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public string FullName
        {
            get => $"{FirstName} {LastName}";
            set
            {
                var parts = value.Split(' ', 2);
                FirstName = parts[0];
                LastName = parts.Length > 1 ? parts[1] : "";
            }
        }
        [MaxLength(500)]
        public string? Bio { get; set; }

        [MaxLength(250)]
        public string? ImageUrl { get; set; }
        [MaxLength(100)]
        public string? Nationality { get; set; }   // ✅ Added

        public bool IsActive { get; set; } = true; // ✅ Added
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

        public ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
        public ICollection<SocialMediaLink> SocialMediaLinks { get; set; } = new List<SocialMediaLink>();

    }

}
