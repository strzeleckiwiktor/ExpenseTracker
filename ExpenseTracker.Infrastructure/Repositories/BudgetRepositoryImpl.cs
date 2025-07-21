using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories
{
    internal class BudgetRepositoryImpl(ExpenseTrackerDbContext dbContext) : IBudgetRepository
    {
        public async Task<IEnumerable<(Budget budget, double amountSpent)>> GetAllBudgetsWithAmountSpentAsync()
        {
            var result = await dbContext.Budgets
                .Select(b => new
                {
                    Budget = b,
                    AmountSpent = b.Expenses.Sum(b => b.Amount)
                })
                .ToListAsync();

            return result.Select(x => (Budget: x.Budget, AmountSpent: x.AmountSpent));
        }

        public async Task<(Budget budget, double amountSpent)?> GetBudgetWithAmountSpentByIdAsync(long id)
        {
            var result = await dbContext.Budgets
                .Where(b => b.Id == id)
                .Select(b => new
                {
                    Budget = b,
                    AmountSpent = b.Expenses.Sum(b => b.Amount)
                })
                .SingleOrDefaultAsync();

            return result == null ? null : (result.Budget, result.AmountSpent);
        }

        public async Task<IEnumerable<Budget>> GetBudgetsByExpenseDateAsync(DateOnly date)
        {
            var result = await dbContext.Budgets.Where(b => b.StartDate <= date && b.EndDate >= date).ToListAsync();
            return result;
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
