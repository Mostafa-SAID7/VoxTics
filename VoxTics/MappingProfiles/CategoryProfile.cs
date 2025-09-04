using AutoMapper;
using VoxTics.Areas.Admin.ViewModels;
using VoxTics.Models.Entities;

namespace VoxTics.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            // Entity -> Admin VM
            CreateMap<Category, CategoryViewModel>();

            // Admin VM -> Entity
            CreateMap<CategoryViewModel, Category>()
                // conditional mapping: only overwrite if value present
                .ForMember(dest => dest.Name, opt =>
                    opt.Condition(src => !string.IsNullOrWhiteSpace(src.Name)))
                .ForMember(dest => dest.Description, opt =>
                    opt.Condition(src => string.IsNullOrWhiteSpace(src.Description) == false));
        }
    }
}
