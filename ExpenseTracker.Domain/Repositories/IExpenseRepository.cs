using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Domain.Repositories
{
    public interface IExpenseRepository
    {
        public Task<IEnumerable<Expense>> GetAllAsync();
        public Task<Expense?> GetByIdAsync(long id);
        public Task<IEnumerable<Expense>> GetExpensesByCategoryAsync(long categoryId);
        public Task<long> CreateAsync(Expense expense);
        public Task UpdateAsync(Expense expense);
        public Task DeleteAsync(Expense expense);
    }
}
