using AutoMapper;
using VoxTics.Models.Entities;
using VoxTics.Models.ViewModels;
using VoxTics.Areas.Admin.ViewModels;

namespace VoxTics.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Admin form mapping
            CreateMap<User, UserViewModel>().ReverseMap();

            // Public-facing mapping
            CreateMap<User, UserVM>();
        }
    }
}
