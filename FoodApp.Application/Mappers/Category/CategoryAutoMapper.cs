using AutoMapper;
using FoddApp.Application.Models.CategoryModels;
using FoodApp.Domain.Entities;

namespace FoodApp.Application.Mappers.Category
{
    public class CatagoryAutoMap : Profile
    {
        public CatagoryAutoMap()
        {
            CreateMap<CategoryEntity, CategoryResponseModel>()
                .ForMember(response => response.Name, opt => opt.MapFrom(entity => entity.Name))
               .ForMember(response => response.Color, opt => opt.MapFrom(entity => entity.Color))
               .ForMember(response => response.Description, opt => opt.MapFrom(entity => entity.Description));

            CreateMap<CategoryRequestModel, CategoryEntity>()
                .ForMember(entity => entity.Name, opt => opt.MapFrom(request => request.Name))
                .ForMember(entity => entity.Color, opt => opt.MapFrom(request => request.Color))
                .ForMember(entity => entity.Description, opt => opt.MapFrom(request => request.Description));
        }
    }
}
