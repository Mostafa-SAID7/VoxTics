using System.ComponentModel.DataAnnotations;

namespace VoxTics.Helpers.Filters.Sorting
{
    public enum SortOrder
    {
        [Display(Name = "Ascending")]
        Asc = 0,

        [Display(Name = "Descending")]
        Desc = 1
    }



}
