using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories
{
    internal class BudgetRepositoryImpl(ExpenseTrackerDbContext dbContext) : IBudgetRepository
    {
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

        public async Task<IEnumerable<Budget>> GetAllAsync()
        {
            var budgets = await dbContext.Budgets.ToListAsync();
            return budgets;
        }

        public async Task<Budget?> GetByIdAsync(long id)         
        {
            var budget = await dbContext.Budgets.SingleOrDefaultAsync(b => b.Id == id);
            return budget;
        }

        public async Task UpdateAsync(Budget budget)
        {
            dbContext.Update(budget);
            await dbContext.SaveChangesAsync();
        }
    }
}
