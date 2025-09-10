using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Enums.Sorting
{
    public enum BookingSortBy
    {
        [Display(Name = "Booking Date")]
        BookingDate = 0,

        [Display(Name = "Show Date")]
        ShowDate = 1,

        [Display(Name = "Movie Title")]
        MovieTitle = 2,

        [Display(Name = "Cinema")]
        Cinema = 3,

        [Display(Name = "Total Amount")]
        TotalAmount = 4,

        [Display(Name = "Status")]
        Status = 5
    }
}
