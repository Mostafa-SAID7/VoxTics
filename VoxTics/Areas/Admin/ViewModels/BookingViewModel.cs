using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Admin.ViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Showtime")]
        public int ShowtimeId { get; set; }

        [Required]
        [Display(Name = "User")]
        public int UserId { get; set; }

        [Required]
        [Range(1, 20)]
        public int Quantity { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalPrice { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
