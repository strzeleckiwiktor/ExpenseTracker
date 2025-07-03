using AutoMapper;
using ExpenseTracker.API.DTOs.Category;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.API.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>();

            CreateMap<CreateCategoryDTO, Category>()
                .ForMember(d => d.Id, opt => opt.Ignore());

            CreateMap<UpdateCategoryDTO, Category>()
                .ForMember(d => d.Id, opt => opt.Ignore());
        }
    }
}
