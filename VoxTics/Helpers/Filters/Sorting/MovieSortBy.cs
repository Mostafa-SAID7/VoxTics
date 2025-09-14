using System.ComponentModel.DataAnnotations;

namespace VoxTics.Helpers.Filters.Sorting
{
    public enum MovieSortBy
    {
        [Display(Name = "Title")]
        Title = 0,

        [Display(Name = "Release Date")]
        ReleaseDate = 1,

        [Display(Name = "Rating")]
        Rating = 2,

        [Display(Name = "Duration")]
        Duration = 3,

        [Display(Name = "Popularity")]
        Popularity = 4
    }
}
