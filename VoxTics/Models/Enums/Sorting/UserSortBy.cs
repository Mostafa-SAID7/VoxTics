namespace VoxTics.Models.Enums.Sorting
{
    public enum UserSortBy
    {
        [Display(Name = "Name")]
        Name = 1,

        [Display(Name = "Email")]
        Email = 2,

        [Display(Name = "Role")]
        Role = 3,

        [Display(Name = "Registration Date")]
        RegistrationDate = 4,

        [Display(Name = "Last Login Date")]
        LastLoginDate = 5
    }
}
