using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Services
{
    internal class BudgetServiceImpl : IBudgetService
    {
        public Task<long> Create(Budget budget)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Budget>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Budget?> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task Update(long id, string name, double amount, DateOnly startDate, DateOnly endDate)
        {
            throw new NotImplementedException();
        }
    }
}
