using AutoMapper;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;

namespace VoxTics.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // For showing a user's public profile
            CreateMap<User, UserVM>().ReverseMap();

            // For user editing own profile
            CreateMap<User, UserEditVM>().ReverseMap();

            // For admin management view
            CreateMap<User, UserAdminVM>().ReverseMap();

            // For registration (map VM -> Entity, password handled separately)
            CreateMap<RegisterVM, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // hash manually
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => "User"))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            // LoginVM does not need mapping → used only for auth input
        }
    }
}
