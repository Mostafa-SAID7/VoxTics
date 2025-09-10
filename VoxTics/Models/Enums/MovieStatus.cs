using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Enums
{
    public enum MovieStatus
    {
        [Display(Name = "Upcoming")]
        [Description("Movie is scheduled for future release")]
        Upcoming = 0,

        [Display(Name = "Now Showing")]
        [Description("Movie is currently being shown in cinemas")]
        NowShowing = 1,

        [Display(Name = "Ended")]
        [Description("Movie has finished its cinema run")]
        Ended = 2,

        [Display(Name = "Cancelled")]
        [Description("Movie release has been cancelled")]
        Cancelled = 3
    }
}
