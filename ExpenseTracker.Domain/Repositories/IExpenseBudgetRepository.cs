using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain.Repositories
{
    public interface IExpenseBudgetRepository
    {
        public Task<IEnumerable<ExpenseBudget>> GetAllAsync();
        public Task CreateAsync(ExpenseBudget expenseBudget);
        public Task UpdateAsync(ExpenseBudget expenseBudget);
        public Task DeleteAsync(ExpenseBudget expenseBudget);
    }
}
