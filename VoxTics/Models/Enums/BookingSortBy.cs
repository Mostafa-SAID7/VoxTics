using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Enums
{
    public enum BookingSortBy
    {
        [Display(Name = "Booking Date")]
        BookingDate = 1,

        [Display(Name = "Show Date")]
        ShowDate = 2,

        [Display(Name = "Movie Title")]
        MovieTitle = 3,

        [Display(Name = "Cinema")]
        Cinema = 4,

        [Display(Name = "Total Amount")]
        TotalAmount = 5,

        [Display(Name = "Status")]
        Status = 6
    }
}
