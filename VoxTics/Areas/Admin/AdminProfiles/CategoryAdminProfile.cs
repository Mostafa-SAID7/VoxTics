using AutoMapper;
using VoxTics.Areas.Admin.ViewModels.Category;
using VoxTics.Models.Entities;

namespace VoxTics.Areas.Admin.AdminProfiles
{
    public class CategoryAdminProfile : Profile
    {
        public CategoryAdminProfile()
        {
            // Category -> CategoryViewModel
            CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.MovieCategories.Select(mc => mc.Movie.Title)));

            // Category -> CategoryTableViewModel
            CreateMap<Category, CategoryTableViewModel>()
                .ForMember(dest => dest.MovieCount, opt => opt.MapFrom(src => src.MovieCategories.Count))
                .ForMember(dest => dest.StatusBadge, opt => opt.MapFrom(src => src.IsActive ? "badge bg-success" : "badge bg-secondary"));

            // Category -> CategoryDetailsViewModel
            CreateMap<Category, CategoryDetailsViewModel>()
                .ForMember(dest => dest.MovieCount, opt => opt.MapFrom(src => src.MovieCategories.Count))
                .ForMember(dest => dest.UpdatedAtFormatted, opt => opt.MapFrom(src => src.UpdatedAt.HasValue ? src.UpdatedAt.Value.ToString("MMM dd, yyyy") : null));

            // CategoryCreateEditViewModel -> Category
            CreateMap<CategoryCreateEditViewModel, Category>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Slug, opt => opt.MapFrom(src => src.Slug))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive));
        }
    }
}
