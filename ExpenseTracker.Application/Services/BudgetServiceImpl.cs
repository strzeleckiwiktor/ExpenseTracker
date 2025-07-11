using ExpenseTracker.Application.Exceptions;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;

namespace ExpenseTracker.Application.Services
{
    internal class BudgetServiceImpl(IBudgetRepository budgetRepository) : IBudgetService
    {
        public async Task<long> Create(Budget budget)
        {
            var id = await budgetRepository.CreateAsync(budget);
            return id;
        }

        public async Task Delete(long id)
        {
            var budget = await budgetRepository.GetByIdAsync(id);

            if (budget == null)
            {
                throw new NotFoundException($"Budget with Id: {id} not found.");
            }

            await budgetRepository.DeleteAsync(budget);
        }

        public async Task<IEnumerable<Budget>> GetAll()
        {
            var budgets = await budgetRepository.GetAllAsync();
            return budgets;
        }

        public async Task<Budget?> GetById(long id)
        {
            var budget = await budgetRepository.GetByIdAsync(id);

            if (budget == null)
            {
                throw new NotFoundException($"Budget with Id: {id} not found.");
            }

            return budget;
        }

        public Task Update(long id, string name, double amount, DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }
    }
}
