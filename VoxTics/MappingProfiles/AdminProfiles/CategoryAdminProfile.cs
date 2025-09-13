using AutoMapper;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;

namespace VoxTics.MappingProfiles.AdminProfiles
{
    public class CategoryAdminProfile : Profile
    {
        public CategoryAdminProfile()
        {
            // Entity to ViewModel mappings
            CreateMap<Category, CategoryVM>()
                .ForMember(dest => dest.MovieCount, opt => opt.MapFrom(src => src.MovieCategories.Count));

            CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.MovieCount, opt => opt.MapFrom(src => src.MovieCategories.Count));

            // ViewModel to Entity mappings
            CreateMap<CategoryViewModel, Category>()
                .ForMember(dest => dest.MovieCategories, opt => opt.Ignore());

            CreateMap<CategoryVM, Category>()
                .ForMember(dest => dest.MovieCategories, opt => opt.Ignore());
        }
    }
}
