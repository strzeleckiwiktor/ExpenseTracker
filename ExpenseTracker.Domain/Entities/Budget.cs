using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain.Entities
{
    public class Budget
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public double Amount { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
