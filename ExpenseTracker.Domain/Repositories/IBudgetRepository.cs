using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain.Repositories
{
    public interface IBudgetRepository 
    {
        public Task<IEnumerable<Budget>> GetAllAsync();
        public Task<Budget?> GetByIdAsync(long id);
        public Task<long> CreateAsync(Budget budget);
        public Task UpdateAsync(Budget budget);
        public Task DeleteAsync(Budget budget);
    }
}
