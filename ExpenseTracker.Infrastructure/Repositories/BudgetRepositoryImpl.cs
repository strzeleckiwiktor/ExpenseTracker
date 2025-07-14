using ExpenseTracker.Application.Exceptions;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.Infrastructure.Repositories
{
    internal class BudgetRepositoryImpl(ExpenseTrackerDbContext dbContext, ILogger<BudgetRepositoryImpl> logger) : IBudgetRepository
    {
        public async Task<IEnumerable<(Budget budget, double amountSpent)>> GetAllBudgetsWithAmountSpentAsync()
        {
            var result = await (
                from budget in dbContext.Budgets
                join expenseBudget in dbContext.ExpenseBudgetAssociations on budget.Id equals expenseBudget.BudgetId into eb
                select new
                {
                    Budget = budget,
                    AmountSpent = (from assoc in eb
                                   join expense in dbContext.Expenses on assoc.ExpenseId equals expense.Id
                                   select expense.Amount).Sum()
                }
            ).ToListAsync();


            return result.Select(x => (Budget: x.Budget, AmountSpent: x.AmountSpent));
        }

        public async Task<(Budget budget, double amountSpent)?> GetBudgetWithAmountSpentByIdAsync(long id)
        {
            var result = await (
                from budget in dbContext.Budgets
                where budget.Id == id
                join expenseBudget in dbContext.ExpenseBudgetAssociations on budget.Id equals expenseBudget.BudgetId into eb
                select new
                {
                    Budget = budget,
                    AmountSpent = (from assoc in eb
                                   join expense in dbContext.Expenses on assoc.ExpenseId equals expense.Id
                                   select expense.Amount).Sum()
                }
            ).SingleOrDefaultAsync();

            if (result == null)
            {
                return null;
            }

            return (result.Budget, result.AmountSpent);
        }

        public async Task<IEnumerable<Budget>> GetBudgetsByExpenseDate(DateOnly date)
        {
            var budgets = from budget in dbContext.Budgets
                          where date >= budget.StartDate && date <= budget.EndDate
                          select budget;

            return await budgets.ToListAsync();
        }

        public async Task<long> CreateAsync(Budget budget)
        {
            dbContext.Add(budget);
            await dbContext.SaveChangesAsync();
            return budget.Id;
        }

        public async Task DeleteAsync(Budget budget)
        {
            dbContext.Remove(budget);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Budget budget)
        {
            dbContext.Update(budget);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Budget?> GetByIdAsync(long id)
        {
            var budget = await dbContext.Budgets.SingleOrDefaultAsync(b => b.Id == id);
            return budget;
        }

        public async Task<IEnumerable<Budget>> GetAllAsync()
        {
            var budgets = await dbContext.Budgets.ToListAsync();
            return budgets;
        }
    }
}
