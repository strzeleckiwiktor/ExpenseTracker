namespace ExpenseTracker.API.DTOs.Expense
{
    public record UpdateExpenseDTO(
        string Name,
        double Amount,
        string Description,
        long CategoryId
    );
}
