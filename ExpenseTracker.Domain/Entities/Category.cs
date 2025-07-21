﻿namespace ExpenseTracker.Domain.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<Expense> Expenses { get; } = default!;
    }
}
