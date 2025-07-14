using ExpenseTracker.Application.Exceptions;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Application.Models;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.Application.Services
{
    internal class BudgetServiceImpl(
        IBudgetRepository budgetRepository,
        IExpenseRepository expenseRepository,
        ILogger<BudgetServiceImpl> logger
        ) : IBudgetService
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

        public async Task<IEnumerable<BudgetDetails>> GetAllBudgetsWithAmountSpent()
        {
            var budgets = await budgetRepository.GetAllBudgetsWithAmountSpentAsync();

            foreach ((Budget, double) budgetDetails in budgets)
            {
                logger.LogInformation($"Budget: {budgetDetails.Item1}, spent: {budgetDetails.Item2}");
            }

            return budgets.Select(b => new BudgetDetails(b.budget, b.amountSpent));
        }

        public async Task<BudgetDetails> GetById(long id)
        {
            var budget = await budgetRepository.GetBudgetWithAmountSpentByIdAsync(id);

            if (budget == null)
            {
                throw new NotFoundException($"Budget with Id: {id} not found.");
            }

            var budgetDetails = new BudgetDetails(budget.Value.budget, budget.Value.amountSpent);
            return budgetDetails;
        }

        public Task Update(long id, string name, double amount, DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }
    }
}
