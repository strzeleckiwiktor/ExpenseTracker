using ExpenseTracker.Application.Models;
using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Interfaces
{
    public interface IBudgetService
    {
        public Task<IEnumerable<BudgetDetails>> GetAllBudgetsWithAmountSpent();
        public Task<BudgetDetails> GetById(long id);
        public Task<long> Create(Budget budget);
        public Task Update(long id, string name, double amount, DateOnly startDate, DateOnly endDate);
        public Task Delete(long id);
    }
}
