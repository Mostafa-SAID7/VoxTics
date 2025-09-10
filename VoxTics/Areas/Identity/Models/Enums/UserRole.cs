using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Areas.Identity.Models.Enums
{
    public enum UserRole
    {
        [Display(Name = "Customer")]
        Customer = 0,

        [Display(Name = "Staff")]
        Staff = 1,

        [Display(Name = "Manager")]
        Manager = 2,

        [Display(Name = "Admin")]
        Admin = 3,

        [Display(Name = "Super Admin")]
        SuperAdmin = 4
    }
}
