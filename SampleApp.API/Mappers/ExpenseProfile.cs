using AutoMapper;
using ExpenseTracker.API.DTOs.Expense;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.API.Mappers
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense, ExpenseDTO>()
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateExpenseDTO, Expense>()
                .ForMember(d => d.Id, opt => opt.Ignore());
        }
    }
}
