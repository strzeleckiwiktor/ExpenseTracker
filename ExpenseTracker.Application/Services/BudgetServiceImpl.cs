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
        IExpenseRepository expenseRepository
        ) : IBudgetService
    {
        public async Task<long> Create(Budget budget)
        {
            var expenses = await expenseRepository.GetExpensesBetweenDatesAsync(budget.StartDate, budget.EndDate);

            foreach (Expense expense in expenses)
            {
                budget.Expenses.Add(expense);
            }

            return await budgetRepository.CreateAsync(budget);
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

        public async Task<IEnumerable<BudgetDetails>> GetAllBudgetsWithAmountSpent()
        {
            var budgets = await budgetRepository.GetAllBudgetsWithAmountSpentAsync();
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
