using AutoMapper;
using Domain.Entities.Categories;

namespace Application.Categories.Commons
{
    public sealed class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
