using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using VoxTics.Models.ViewModels.Showtime;

namespace VoxTics.Areas.Admin.ViewModels.Cinema
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


        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters")]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }



        [Display(Name = "Cinema Image")]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "Image URL")]
        public Uri? ImageUrl { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;


        public int TotalSeats { get; set; }
        public int HallCount { get; set; }
        public int ShowtimeCount { get; set; }


        public List<ShowtimeVM> Showtimes { get; set; } = new List<ShowtimeVM>();


    }
}
