using System.Text.Json.Serialization;

namespace ExpenseTracker.Domain.Entities
{
    public class Expense
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public double Amount { get; set; }
        public string? Description { get; set; }
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public long CategoryId { get; set; }

        public Category Category { get; set; } = default!;
        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
    }
}
