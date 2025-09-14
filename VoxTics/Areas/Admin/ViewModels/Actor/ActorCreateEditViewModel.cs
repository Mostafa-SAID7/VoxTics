using System;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Admin.ViewModels.Actor
{
    public class ActorCreateEditViewModel
    {
        public int Id { get; set; } // For edit scenarios

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(50, ErrorMessage = "First name cannot exceed 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Bio cannot exceed 500 characters")]
        public string? Bio { get; set; }

        [Url(ErrorMessage = "Image URL must be a valid URL")]
        [StringLength(250, ErrorMessage = "Image URL cannot exceed 250 characters")]
        public string? ImageUrl { get; set; }

        [StringLength(100, ErrorMessage = "Nationality cannot exceed 100 characters")]
        public string? Nationality { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Date of birth must be a valid date")]
        public DateTime? DateOfBirth { get; set; }

        public bool IsActive { get; set; } = true;

        // -------------------------
        // Computed / Display properties
        // -------------------------
        public string FullName => $"{FirstName} {LastName}".Trim();

        [Display(Name = "Age")]
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
    }
}
