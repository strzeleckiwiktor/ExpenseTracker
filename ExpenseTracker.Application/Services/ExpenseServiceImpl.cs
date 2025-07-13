using ExpenseTracker.Application.Exceptions;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using Microsoft.Extensions.Logging;
using System.Data.Entity.Core.Mapping;

namespace ExpenseTracker.Application.Services
{
    internal class ExpenseServiceImpl(
        IExpenseRepository expenseRepository,
        ICategoryRepository categoryRepository,
        IBudgetRepository budgetRepository,
        IExpenseBudgetRepository expenseBudgetRepository,
        ILogger<ExpenseServiceImpl> logger
        ) : IExpenseService
    {
        public async Task<IEnumerable<Expense>> GetAll()
        {
            var expenses = await expenseRepository.GetAllAsync();
            return expenses;
        }

        public async Task<Expense?> GetById(long id)
        {
            var expense = await expenseRepository.GetByIdAsync(id);

            if (expense == null)
            {
                throw new NotFoundException($"Expense with Id {id} not found.");
            }

            return expense;
        }

        public async Task<IEnumerable<Expense>> GetExpensesByCategory(long categoryId)
        {
            if (!await categoryRepository.ExistsAsync(categoryId))
                throw new NotFoundException($"Category with Id {categoryId} not found.");

            var expenses = await expenseRepository.GetExpensesByCategoryAsync(categoryId);
            return expenses;
        }

        public async Task<long> Create(Expense expense)
        {
            var categoryId = expense.CategoryId;
            var category = await categoryRepository.GetByIdAsync(categoryId);

            if (category == null)
            {
                throw new ArgumentException($"Category with Id: {categoryId} not found.");
            }

            expense.Category = category;
            var expenseId = await expenseRepository.CreateAsync(expense);

            var budgets = await budgetRepository.GetBudgetsByExpenseDate(expense.Date);

            foreach (Budget budget in budgets)
            {
                var expenseBudget = new ExpenseBudget
                {
                    BudgetId = budget.Id,
                    ExpenseId = expenseId,
                };
                await expenseBudgetRepository.CreateAsync(expenseBudget);
            }

            return expenseId;
        }

        public async Task Update(long id, string name, double amount, DateOnly date, string description, long categoryId)
        {
            var expense = await expenseRepository.GetByIdAsync(id);

            if (expense == null)
            {
                throw new NotFoundException($"Expense with Id: {id} not found.");
            }

            var category = await categoryRepository.GetByIdAsync(categoryId);

            if (category == null)
            {
                throw new ArgumentException($"Category with Id: {categoryId} not found.");
            }

            expense.Name = name;
            expense.Amount = amount;
            expense.Description = description;
            expense.Date = date;
            expense.CategoryId = categoryId;
            expense.Category = category;

            await expenseRepository.UpdateAsync(expense);
        }

        public async Task Delete(long id)
        {
            var expense = await expenseRepository.GetByIdAsync(id);

            if (expense == null)
            {
                throw new NotFoundException($"Expense with Id {id} not found");
            }

            await expenseRepository.DeleteAsync(expense);
        }
    }
}
