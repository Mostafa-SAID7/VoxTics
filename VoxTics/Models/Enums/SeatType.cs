using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VoxTics.Models.Enums
{
    public enum SeatType
    {
        [Display(Name = "Standard")]
        [Description("Regular cinema seat")]
        Standard = 0,

        [Display(Name = "VIP")]
        [Description("VIP seat with extra comfort")]
        VIP = 1,

        [Display(Name = "Premium")]
        [Description("Premium seat with best view")]
        Premium = 2,

        [Display(Name = "Disabled Access")]
        [Description("Seat accessible for disabled persons")]
        DisabledAccess = 3,

        [Display(Name = "Couple Seat")]
        [Description("Seat for couples")]
        CoupleSeat = 4
    }
}
