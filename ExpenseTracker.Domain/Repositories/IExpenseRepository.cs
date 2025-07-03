using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Domain.Repositories
{
    public interface IExpenseRepository
    {
        public Task<IEnumerable<Expense>> GetAllAsync();
        public Task<Expense?> GetByIdAsync(long id);
        public Task<long> CreateAsync(Expense expense);
        public Task<Expense> UpdateAsync(Expense expense);
        public Task<Expense> DeleteAsync(Expense expense);
    }
}
