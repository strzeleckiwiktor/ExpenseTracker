using System.Data.Entity.Core.Mapping;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace ExpenseTracker.Application.Services
{
    internal class ExpenseServiceImpl(
        IExpenseRepository expenseRepository,
        ICategoryRepository categoryRepository,
        ILogger<ExpenseServiceImpl> logger
        ) : IExpenseService
    {
        public async Task<IEnumerable<Expense>> GetAll()
        {
            logger.LogInformation("Getting all expenses");
            var expenses = await expenseRepository.GetAllAsync();

            return expenses;
        }

        public async Task<Expense?> GetById(long id)
        {
            var expense = await expenseRepository.GetByIdAsync(id);

            if (expense == null)
            {
                throw new KeyNotFoundException("Entity not found");
            }

            return expense;
        }

        public async Task<long> Create(Expense expense)
        {
            var category = await categoryRepository.GetByIdAsync(expense.CategoryId);

            if (category == null)
            {
                throw new ArgumentException("Invalid category id");
            }

            expense.Category = category;
            return await expenseRepository.CreateAsync(expense);
        }

        public async Task Update(long id, string name, double amount, long categoryId)
        {
            var expense = await expenseRepository.GetByIdAsync(id);

            if (expense == null)
            {
                throw new KeyNotFoundException("Entity not found");
            }

            var category = await categoryRepository.GetByIdAsync(categoryId);

            if (category == null)
            {
                throw new ArgumentException("Invalid category id");
            }

            expense.Name = name;
            expense.Amount = amount;
            expense.CategoryId = categoryId;
            expense.Category = category;

            await expenseRepository.UpdateAsync(expense);
        }

        public async Task Delete(long id)
        {
            var expense = await expenseRepository.GetByIdAsync(id);

            if (expense == null)
            {
                throw new KeyNotFoundException("Entity not found");
            }

            await expenseRepository.DeleteAsync(expense);
        }
    }
}
