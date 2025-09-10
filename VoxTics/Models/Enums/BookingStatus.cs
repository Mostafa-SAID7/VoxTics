using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Enums
{
    public enum BookingStatus
    {
        [Display(Name = "Pending")]
        [Description("Booking is waiting for confirmation")]
        Pending = 0,

        [Display(Name = "Confirmed")]
        [Description("Booking has been confirmed")]
        Confirmed = 1,

        [Display(Name = "Completed")]
        [Description("Movie show has been completed")]
        Completed = 2,

        [Display(Name = "Cancelled")]
        [Description("Booking has been cancelled")]
        Cancelled = 3,

        [Display(Name = "Rejected")]
        [Description("Booking has been rejected")]
        Rejected = 4,

        [Display(Name = "No Show")]
        [Description("Customer did not show up")]
        NoShow = 5
    }
}
