using System.ComponentModel.DataAnnotations;

namespace VoxTics.Helpers.Filters.TimeRange
{
    public enum TimeRange
    {
        [Display(Name = "Today")]
        Today = 0,

        [Display(Name = "This Week")]
        ThisWeek = 1,

        [Display(Name = "This Month")]
        ThisMonth = 2,

        [Display(Name = "Last 30 Days")]
        Last30Days = 3,

        [Display(Name = "Last 90 Days")]
        Last90Days = 4,

        [Display(Name = "This Year")]
        ThisYear = 5,

        [Display(Name = "All Time")]
        AllTime = 6
    }

}
