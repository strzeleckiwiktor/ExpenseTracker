using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Infrastructure.Repositories
{
    internal class ExpenseRepositoryImpl(ExpenseTrackerDbContext dbContext) : IExpenseRepository
    {

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            var expenses = await dbContext.Expenses
                .Include(e => e.Category)
                .ToListAsync();

            return expenses;
        }

        public async Task<Expense?> GetByIdAsync(long id)
        {
            var expense = await dbContext.Expenses
                .Include(e => e.Category)
                .SingleOrDefaultAsync(e => e.Id == id);

            return expense;
        }

        public async Task<long> CreateAsync(Expense expense)
        {
            dbContext.Expenses.Add(expense);
            await dbContext.SaveChangesAsync();
            return expense.Id;
        }

        public async Task<Expense> DeleteAsync(Expense expense)
        {
            dbContext.Expenses.Remove(expense);
            await dbContext.SaveChangesAsync();
            return expense;
        }

        public async Task<Expense> UpdateAsync(Expense expense)
        {
            dbContext.Expenses.Update(expense);
            await dbContext.SaveChangesAsync();
            return expense;
        }
    }
}
