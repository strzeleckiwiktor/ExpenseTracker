using AutoMapper;
using ExpenseTracker.API.DTOs.Budget;
using ExpenseTracker.Application.Models;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.API.Mappers
{
    public class BudgetProfile : Profile
    {
        public BudgetProfile()
        {
            CreateMap<BudgetDetails, BudgetDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Budget.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Budget.Name))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Budget.Amount))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.Budget.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.Budget.EndDate))
                .ForMember(dest => dest.Remaining, opt => opt.MapFrom(src => src.Budget.Amount - src.TotalSpent));

            CreateMap<CreateBudgetDTO, Budget>()
                .ForMember(d => d.Id, opt => opt.Ignore());

            CreateMap<Budget, BudgetDTO>()
                .ForMember(d => d.Remaining, opt => opt.Ignore());
        }
    }
}
