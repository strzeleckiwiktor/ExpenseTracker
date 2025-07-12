using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain.Entities
{
    public class ExpenseBudget
    {
        public long Id { get; set; }
        public long ExpenseId { get; set; }
        public long BudgetId { get; set; }
    }
}
