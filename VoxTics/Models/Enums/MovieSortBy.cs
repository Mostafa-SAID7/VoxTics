using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Enums
{
    public enum MovieSortBy
    {
        [Display(Name = "Title")]
        Title = 1,

        [Display(Name = "Release Date")]
        ReleaseDate = 2,

        [Display(Name = "Rating")]
        Rating = 3,

        [Display(Name = "Duration")]
        Duration = 4,

        [Display(Name = "Popularity")]
        Popularity = 5
    }
}
