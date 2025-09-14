namespace VoxTics.Helpers.Filters.TimeRange
{

    public enum TimeOfDayRange
    {
        [Display(Name = "Morning (6–12)")]
        Morning = 0,

        [Display(Name = "Afternoon (12–18)")]
        Afternoon = 1,

        [Display(Name = "Evening (18–24)")]
        Evening = 2,

        [Display(Name = "Night (0–6)")]
        Night = 3
    }
}
