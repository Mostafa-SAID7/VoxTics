using AutoMapper;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;

namespace VoxTics.Areas.Identity.IdentityProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            // User mappings
            CreateMap<RegisterVM, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.EmailConfirmed, opt => opt.MapFrom(src => false));

            CreateMap<ApplicationUser, PersonalInfoVM>()
                .ReverseMap();

            CreateMap<ApplicationUser, ManageProfileVM>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src))
                .ForMember(dest => dest.AvatarUrl, opt => opt.Ignore())
                .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.AvatarUrl));
        }

    }
}
