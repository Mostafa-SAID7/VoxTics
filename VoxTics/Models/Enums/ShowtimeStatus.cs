using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Enums
{
    public enum ShowtimeStatus
    {
        [Display(Name = "Scheduled")]
        [Description("Showtime is scheduled")]
        Scheduled = 0,

        [Display(Name = "Active")]
        [Description("Showtime is currently active")]
        Active = 1,

        [Display(Name = "Completed")]
        [Description("Show has been completed")]
        Completed = 2,

        [Display(Name = "Cancelled")]
        [Description("Showtime has been cancelled")]
        Cancelled = 3,

        [Display(Name = "Postponed")]
        [Description("Showtime has been postponed")]
        Postponed = 4
    }
}
