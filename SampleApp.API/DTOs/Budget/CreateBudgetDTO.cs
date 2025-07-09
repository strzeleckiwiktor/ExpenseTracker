namespace ExpenseTracker.API.DTOs.Budget
{
    public record CreateBudgetDTO(
        string Name,
        double Amount,
        DateOnly StartDate,
        DateOnly EndDate
        );
}
