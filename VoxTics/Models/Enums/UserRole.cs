using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Enums
{
    public enum UserRole
    {
        [Display(Name = "Customer")]
        Customer = 1,

        [Display(Name = "Staff")]
        Staff = 2,

        [Display(Name = "Manager")]
        Manager = 3,

        [Display(Name = "Admin")]
        Admin = 4,

        [Display(Name = "Super Admin")]
        SuperAdmin = 5
    }
}
