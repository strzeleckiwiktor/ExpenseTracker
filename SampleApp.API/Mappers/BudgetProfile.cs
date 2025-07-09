using AutoMapper;
using ExpenseTracker.API.DTOs.Budget;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.API.Mappers
{
    public class BudgetProfile : Profile
    {
        public BudgetProfile()
        {
            CreateMap<Budget, BudgetDTO>();

            CreateMap<CreateBudgetDTO, Budget>()
                .ForMember(d => d.Id, opt => opt.Ignore());
        }
    }
}
