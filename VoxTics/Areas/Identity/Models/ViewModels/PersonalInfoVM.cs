using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VoxTics.Areas.Identity.Models.Enums;

namespace VoxTics.Areas.Identity.Models.ViewModels
{
    public class PersonalInfoVM
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; } = Gender.Male;

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string Address { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "State cannot exceed 100 characters.")]
        public string? State { get; set; }

        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters.")]
        public string? City { get; set; }

        [StringLength(200, ErrorMessage = "Street cannot exceed 200 characters.")]
        public string? Street { get; set; }

        [StringLength(20, ErrorMessage = "Zip code cannot exceed 20 characters.")]
        public string? ZipCode { get; set; }

        // Read-only Skills
        [Required(ErrorMessage = "At least one skill is required.")]
        [MinLength(1, ErrorMessage = "Please provide at least one skill.")]
        public List<string> Skills { get; } = new();

        // Changed to System.Uri
        [Url(ErrorMessage = "Invalid URL format.")]
        public string? AvatarUrl { get; set; }

        // Computed property for convenience
        public int Age => DateOfBirth.HasValue ? (int)((DateTime.UtcNow - DateOfBirth.Value).TotalDays / 365.25) : 0;

        public string FullAddress => $"{Street}, {City}, {State}, {ZipCode}".Trim(',', ' ');

        public object Email { get; internal set; }
        public object CreatedAt { get; internal set; }
    }
}
