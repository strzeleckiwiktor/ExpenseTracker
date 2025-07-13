using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Models
{
    public record BudgetDetails (
        Budget Budget,
        double TotalSpent
        );
    
}
