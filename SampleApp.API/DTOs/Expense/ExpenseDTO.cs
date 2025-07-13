using System.ComponentModel.DataAnnotations;
using ExpenseTracker.API.DTOs.Category;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.API.DTOs.Expense
{
    public record ExpenseDTO(
        long Id, 
        string Name, 
        double Amount,
        DateOnly Date,
        string Description,
        string CategoryName
    );
 
}
