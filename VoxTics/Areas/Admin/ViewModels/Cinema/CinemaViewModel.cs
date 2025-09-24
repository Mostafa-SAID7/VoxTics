using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Admin.ViewModels.Cinema
{
    public class CinemaViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Cinema Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Phone")]
        public string? Phone { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }

        [Display(Name = "Total Seats")]
        public int TotalSeats { get; set; }

        [Display(Name = "Halls")]
        public int HallCount { get; set; }

        [Display(Name = "Showtimes")]
        public int ShowtimeCount { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Display(Name = "Image")]
        public string DisplayImage { get; set; } = "/images/defaults/placeholder.png";
    }
}
