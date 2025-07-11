﻿using ExpenseTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Application.Interfaces
{
    public interface IBudgetService
    {
        public Task<IEnumerable<Budget>> GetAll();
        public Task<Budget?> GetById(long id);
        public Task<long> Create(Budget budget);
        public Task Update(long id, string name, double amount, DateOnly startDate, DateOnly endDate);
        public Task Delete(long id);
    }
}
