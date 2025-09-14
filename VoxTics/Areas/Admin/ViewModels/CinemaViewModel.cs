using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace VoxTics.Areas.Admin.ViewModels
{
    public class CinemaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Cinema name is required")]
        [StringLength(200, ErrorMessage = "Cinema name cannot exceed 200 characters")]
        [Display(Name = "Cinema Name")]
        public string Name { get; set; } = string.Empty;
        [EmailAddress]
        public string? Email { get; set; }
        [StringLength(500, ErrorMessage = "Address cannot exceed 500 characters")]
        [Display(Name = "Address")]
        public string? Address { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "City cannot exceed 100 characters")]
        [Display(Name = "City")]
        public string? City { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Cinema Image")]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "Image URL")]
        public Uri? ImageUrl { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int TotalSeats { get; set; }

        // Display properties
        public int HallCount { get; set; }
        public int ShowtimeCount { get; set; }

        public string CreatedDateFormatted => CreatedDate.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture);
        public string ModifiedDateFormatted => ModifiedDate.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture);
        public List<ShowtimeVM> Showtimes { get; set; } = new List<ShowtimeVM>();
        public List<SocialMediaLinkVM> SocialMediaLinks { get; set; } = new List<SocialMediaLinkVM>();

        public bool HasImage => ImageUrl != null;
        public string DefaultImage => "/images/default-cinema.jpg";
        [Url(ErrorMessage = "Invalid website URL.")]
        public string? Website { get; set; }
        public string DisplayImage => HasImage ? ImageUrl!.ToString() : DefaultImage;
    }
}
