using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Enums
{
    public enum MovieStatus
    {
        [Display(Name = "Coming Soon")]
        [Description("Movie is scheduled for future release")]
        Upcoming = 0,  // unified naming: Upcoming / Coming Soon

        [Display(Name = "Now Playing")]
        [Description("Movie is currently being shown in cinemas")]
        NowShowing = 1, // unified naming: Now Showing / Now Playing

        [Display(Name = "Ended")]
        [Description("Movie has finished its cinema run")]
        EndedShowing = 2, // unified naming: Ended Showing / Ended

        [Display(Name = "Cancelled")]
        [Description("Movie release has been cancelled")]
        Cancelled = 3
    }
}
