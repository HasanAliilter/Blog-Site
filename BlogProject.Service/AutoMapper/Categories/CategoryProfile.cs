using AutoMapper;
using BlogProject.Entity.Dtos.Categories;
using BlogProject.Entity.Entities;

namespace BlogProject.Service.AutoMapper.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
        }
    }
}
