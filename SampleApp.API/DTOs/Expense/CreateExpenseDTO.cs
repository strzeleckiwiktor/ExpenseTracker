using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.API.DTOs.Expense
{
    public record CreateExpenseDTO(
        string Name, 
        double Amount,
        DateOnly Date,
        string Description,
        long CategoryId
    );
   
}
