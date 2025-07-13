using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using ExpenseTracker.Infrastructure.Exceptions;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
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

        public async Task<IEnumerable<Expense>> GetExpensesByCategoryAsync(long categoryId)
        {
            var expenses = await dbContext.Expenses
                .Where(e => e.CategoryId == categoryId)
                .Include(e => e.Category)
                .ToListAsync();

            return expenses;
        }

        public async Task<IEnumerable<Expense>> GetExpensesByBudgetId(long budgetId)
        {
            var expenses =
                from expense in dbContext.Expenses
                join expenseBudget in dbContext.ExpenseBudgetAssociations
                on expense.Id equals expenseBudget.ExpenseId
                where expenseBudget.BudgetId == budgetId
                select expense;

            return await expenses.ToListAsync();
        }

        public async Task<double> GetTotalSpentAmountByBudgetId(long budgetId)
        {
            var totalSpent = await (
                from expense in dbContext.Expenses
                join expenseBudget in dbContext.ExpenseBudgetAssociations
                on expense.Id equals expenseBudget.ExpenseId
                where expenseBudget.BudgetId == budgetId
                select expense.Amount
            ).SumAsync(); 

            return totalSpent;
        }

        public async Task<long> CreateAsync(Expense expense)
        {
            dbContext.Expenses.Add(expense);
            await dbContext.SaveChangesAsync();
            return expense.Id;
        }

        public async Task DeleteAsync(Expense expense)
        {
            dbContext.Expenses.Remove(expense);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Expense expense)
        {
            dbContext.Expenses.Update(expense);
            await dbContext.SaveChangesAsync();
        }
    }
}
