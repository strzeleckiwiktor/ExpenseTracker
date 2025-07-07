using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Interfaces
{
    public interface IExpenseService
    {
        public Task<IEnumerable<Expense>> GetAll();
        public Task<Expense?> GetById(long id);
        public Task<long> Create(Expense expense);
        public Task Update(long id, string name, double amount, long categoryId);
        public Task Delete(long id);
    }
}
