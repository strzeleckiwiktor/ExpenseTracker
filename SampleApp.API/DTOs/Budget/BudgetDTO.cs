namespace ExpenseTracker.API.DTOs.Budget
{
    public record BudgetDTO(
        long Id,
        string Name,
        double Amount,
        DateOnly StartDate,
        DateOnly EndDate
        );
}
