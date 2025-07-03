using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Interfaces
{
    public interface IExpenseService
    {
        public Task<IEnumerable<Expense>> GetAll();
        public Task<Expense?> GetById(long id);
        public Task<long> Create(Expense expense);
    }
}
