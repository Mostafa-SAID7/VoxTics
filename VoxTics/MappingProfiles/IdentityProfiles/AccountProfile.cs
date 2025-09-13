using AutoMapper;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;

namespace VoxTics.MappingProfiles.AdminProfiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            // Map RegisterVM → ApplicationUser
            CreateMap<RegisterVM, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            // Map ApplicationUser → PersonalInfoVM (profile display/edit)
            CreateMap<ApplicationUser, PersonalInfoVM>()
                .ForMember(dest => dest.FullAddress, opt => opt.Ignore()) // Computed separately
                .ForMember(dest => dest.Age, opt => opt.Ignore());       // Computed separately

            // Map PersonalInfoVM → ApplicationUser (updating profile)
            CreateMap<PersonalInfoVM, ApplicationUser>()
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.ZipCode))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.AvatarUrl));

            // Optional: ApplicationUser → RegisterVM (reverse mapping if you ever need it)
            CreateMap<ApplicationUser, RegisterVM>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }

    }
}
