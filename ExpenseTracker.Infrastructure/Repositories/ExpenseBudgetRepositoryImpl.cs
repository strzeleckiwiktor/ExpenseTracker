using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using ExpenseTracker.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Infrastructure.Repositories
{
    internal class ExpenseBudgetRepositoryImpl(ExpenseTrackerDbContext dbContext) : IExpenseBudgetRepository
    {
        public async Task<IEnumerable<ExpenseBudget>> GetAllAsync()
        {
            var expenseBudgetAssociations = await dbContext.ExpenseBudgetAssociations.ToListAsync();
            return expenseBudgetAssociations;
        }

        public Task UpdateAsync(ExpenseBudget expenseBudget)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(ExpenseBudget expenseBudget)
        {
            dbContext.Add(expenseBudget);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(ExpenseBudget expenseBudget)
        {
            dbContext.Remove(expenseBudget);
            await dbContext.SaveChangesAsync();
        }
    }
}
