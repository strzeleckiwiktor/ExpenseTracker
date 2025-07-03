using System.Text.Json.Serialization;

namespace ExpenseTracker.Domain.Entities
{
    public class Expense
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public double Amount { get; set; }
        public long CategoryId { get; set; }

        //Navigation properties
        public Category Category { get; set; } = default!;
    }
}
