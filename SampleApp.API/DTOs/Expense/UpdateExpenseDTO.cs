namespace ExpenseTracker.API.DTOs.Expense
{
    public record UpdateExpenseDTO(
        string Name,
        double Amount,
        DateOnly Date,
        string Description,
        long CategoryId
    );
}
