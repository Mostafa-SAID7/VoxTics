using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Admin.ViewModels.Cinema
{
    public class CinemaCreateEditViewModel
    {
        public int Id { get; set; } // For Edit scenarios

        [Required(ErrorMessage = "Cinema name is required")]
        [StringLength(120)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        [Phone]
        [StringLength(20)]
        public string? Phone { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(100)]
        public string? State { get; set; }

        [StringLength(100)]
        public string? Country { get; set; }

        [StringLength(20)]
        public string? PostalCode { get; set; }

        [Url]
        [StringLength(200)]
        public string? Website { get; set; }

        [Url]
        [StringLength(200)]
        public string? ImageUrl { get; set; }

        public IFormFile? ImageFile { get; set; }
        public string Slug { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        // Display fallback for image
        public string DisplayImage => !string.IsNullOrEmpty(ImageUrl) ? ImageUrl : "/images/defaults/placeholder.png";
    }
}
