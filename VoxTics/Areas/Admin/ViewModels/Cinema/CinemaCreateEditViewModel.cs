using System;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Admin.ViewModels.Cinema
{
    public class CinemaCreateEditViewModel
    {
        public int Id { get; set; } // For edit scenarios

        [Required(ErrorMessage = "Cinema name is required")]
        [StringLength(120, ErrorMessage = "Name cannot exceed 120 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string? Description { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        public string? Phone { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string? Address { get; set; }

        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters")]
        public string? City { get; set; }

        [StringLength(100, ErrorMessage = "State cannot exceed 100 characters")]
        public string? State { get; set; }

        [StringLength(100, ErrorMessage = "Country cannot exceed 100 characters")]
        public string? Country { get; set; }

        [StringLength(20, ErrorMessage = "Postal code cannot exceed 20 characters")]
        public string? PostalCode { get; set; }

        [Url(ErrorMessage = "Invalid website URL")]
        [StringLength(200, ErrorMessage = "Website URL cannot exceed 200 characters")]
        public string? Website { get; set; }

        [Url(ErrorMessage = "Invalid image URL")]
        [StringLength(200, ErrorMessage = "Image URL cannot exceed 200 characters")]
        public string? ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        // -------------------------
        // Optional display properties
        // -------------------------
        public int HallCount { get; set; } = 0;
        public int TotalSeats { get; set; } = 0;
        public int ShowtimeCount { get; set; } = 0;

        public string DisplayImage => !string.IsNullOrEmpty(ImageUrl) ? ImageUrl : "/images/default-cinema.jpg";
    }
}
