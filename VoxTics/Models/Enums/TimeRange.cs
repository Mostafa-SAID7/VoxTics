using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Enums
{
    public enum TimeRange
    {
        [Display(Name = "Today")]
        Today = 1,

        [Display(Name = "This Week")]
        ThisWeek = 2,

        [Display(Name = "This Month")]
        ThisMonth = 3,

        [Display(Name = "Last 30 Days")]
        Last30Days = 4,

        [Display(Name = "Last 90 Days")]
        Last90Days = 5,

        [Display(Name = "This Year")]
        ThisYear = 6,

        [Display(Name = "All Time")]
        AllTime = 7
    }
}
